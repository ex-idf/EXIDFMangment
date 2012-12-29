using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using ExIDFManagment.Interface;
using ExIDFManagment.Mail;

namespace ExIDFManagment.DataModel
{
    public class CandidatesManagment : ICandidateManagment
    {
        private MailSender mMailSender;
        private Entities mEntity = EntitiesManager.Entity;

        public Entities Entity
        {
            get { return mEntity; }
        }

        public bool AddCandidate(string name, DateTime dateOfBirth, string mail, int excpectedSalary, 
            string cvPath, string militaryUnit, string location, string phone)
        {
            Candidates candidateModel =
                Candidates.CreateCandidates(Guid.NewGuid().ToString(), name, 0);
            candidateModel.Expected_Salary = excpectedSalary;
            candidateModel.Email = mail;
            candidateModel.DateOfBirth = dateOfBirth;
            candidateModel.CV_Path = cvPath;
            candidateModel.Location = location;
            candidateModel.Phone = phone;
            candidateModel.Military_Unit = militaryUnit;
            try
            {
                mEntity.AddToCandidates(candidateModel);
                mEntity.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                return false;
            }
            return true;
        }

        public bool RemoveCandidate(ICandidate candidate)
        {
            try
            {
                Candidates candidateModel = mEntity.Candidates.Where(x => x.PK == candidate.ID).First();
                mEntity.Candidates.DeleteObject(candidateModel);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateCandidate(ICandidate candidate)
        {
            throw new NotImplementedException();
        }
    
        public ICandidate GetCandidate(string candidateId)
        {
            return mEntity.Candidates.First(x => x.PK == candidateId);
        }
    
        public IEnumerable<ICandidate> GetAllCandidates()
        {
            return mEntity.Candidates.AsEnumerable();
        }
    
        public IEnumerable<ICandidate> GetCandidateContainsName(string name)
        {
            return mEntity.Candidates.Where(can => can.Name.Contains(name));
        }

        public bool CommitChanges()
        {
            try
            {
                mEntity.SaveChanges();
                mEntity.Refresh(RefreshMode.ClientWins, mEntity.Candidates);
                return true;
            }
            catch(Exception ex)
            {
                mEntity.Refresh(RefreshMode.StoreWins,mEntity.Candidates);
                mEntity.Refresh(RefreshMode.StoreWins, mEntity.Candidate_To_Employer);
                throw;
            }
            return false;
        }
    
        public IEnumerable<ICandidateCompany> GetCandidateComapnies(string candidateId)
        {
            List<CandidateCompany> results = new List<CandidateCompany>();
            var candidateCompanies = EntitiesManager.Entity.Candidates.
                    Where(cand => cand.PK == candidateId).First().Candidate_To_Employer.AsEnumerable();
            foreach (var company in candidateCompanies)
            {
                results.Add(new CandidateCompany()
                {
                    Candidate = company.Candidates,
                    Company = company.Employers,
                    ExposeTime = company.Expose_Date.GetValueOrDefault(),
                    Status = company.Status
                });
            }
            return results;
        }

        public void AttachCandidateToCompany(string candidateId, string companyId, DateTime attachTime, string status)
        {
            EntitiesManager.Entity.Candidates.Where(cand => cand.PK == candidateId).First().
                Candidate_To_Employer.Add(new Candidate_To_Employer
                                                                                                                          ()
                                                                                                                          {
                                                                                                                              PK = Guid.NewGuid().ToString(),
                                                                                                                              Candidate_FK = candidateId,
                                                                                                                              Employer_FK = companyId,
                                                                                                                              Expose_Date = attachTime,
                                                                                                                              Status =  status
                                                                                                                          });
        }

        public void UpdateCandidateToCompanyStatus(string candidateId, string companyId, DateTime attachTime, string status)
        {
            EntitiesManager.Entity.Candidate_To_Employer.Where(
                cToC => cToC.Candidate_FK == candidateId && cToC.Employer_FK == companyId).First().Status = status;
            EntitiesManager.Entity.Candidate_To_Employer.Where(
                cToC => cToC.Candidate_FK == candidateId && cToC.Employer_FK == companyId).First().Expose_Date = attachTime;
        }
    
        public void Refresh()
        {
            EntitiesManager.Entity.Refresh(RefreshMode.StoreWins, EntitiesManager.Entity.Candidates);
        }

        private void InitMailSettings(bool createNew = false)
        {
            if (mMailSender != null)
            {
                if (!(createNew))
                {
                    return;
                }
            }

            Configuration config =
                    System.Configuration.ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            var mailHost = config.AppSettings.Settings["MailHost"].Value;
            var mailHostPort = Convert.ToInt32(config.AppSettings.Settings["MailHostPort"].Value);
            var username = config.AppSettings.Settings["MailUsername"].Value;
            var password = config.AppSettings.Settings["MailPassword"].Value;
            mMailSender = new MailSender(mailHost, mailHostPort, username, password);
        }

        public void SendWelcomeMail(string candidateId)
        {
            InitMailSettings();
            ICandidate candidate = this.GetCandidate(candidateId);
            if (candidate != null)
            {
                ListDictionary replacers = new ListDictionary(); 
                replacers.Add("<%Name%>", candidate.Name);
                mMailSender.SendMail("office@ex-idf.com", candidate.Mail,
                                     "מידע על EX-IDF", MailSender.MailType.WELCOME_MAIL, replacers);
            }
        }
    }
}
