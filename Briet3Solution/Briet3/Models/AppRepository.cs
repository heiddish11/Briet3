using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briet3.Models
{
    public class AppRepository: IAppRepository
    {
        private AppDataContext m_db = new AppDataContext();

        public void AddfileSRT (FileSRT fileSRT)
        {
            m_db.Files.Add(fileSRT);
            m_db.SaveChanges();
        }
        public void AddTitle(Title title)
        {
            m_db.Titles.Add(title);
            m_db.SaveChanges();
        }


        IEnumerable<Title> IAppRepository.GetTitles
        {
            get
            {
                return m_db.Titles;
            }
            set
            {
            }
        }

        IEnumerable<FileSRT> IAppRepository.GetFiles
        {
            get
            {
                return m_db.Files;
            }
            set
            {
            }
        }
    }
}