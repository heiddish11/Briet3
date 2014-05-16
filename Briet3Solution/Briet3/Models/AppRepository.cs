using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Briet3.Models
{
    public class AppRepository: IAppRepository
    {
        // Creating a new instance of the database variable m_db
        private AppDataContext m_db = new AppDataContext();

        // Creating a List that returns a variable in titles
        IEnumerable<Title> IAppRepository.GetTitles
        {
            get { return m_db.Titles; }
            set { }
        }

        // Creating a List that returns a variable in files
        IEnumerable<FileSRT> IAppRepository.GetFiles
        {
            get { return m_db.Files; }
            set { }
        }

        // A void function that adds a new instance, variable called fileSRT,
        // of class FileSRT and saves it to the database
        public void AddfileSRT (FileSRT fileSRT)
        {
            m_db.Files.Add(fileSRT);
            m_db.SaveChanges();
        }
        // A void function that adds a new instance of class Title 
        // and saves it to the database
        public void AddTitle(Title title)
        {
            m_db.Titles.Add(title);
            m_db.SaveChanges();
        }

        // Function to enable user to download files by id
        public FileSRT GetFile(int id)
        {
            return m_db.Files.Where(file => file.FileSRTID == id).FirstOrDefault();
        }

        // A void function that allows user to edit a file from the database
        // and overrides changes to the original file
        public void SaveFile(FileSRT model)
        {
            FileSRT current = GetFile(model.FileSRTID.Value);
            m_db.Entry(current).CurrentValues.SetValues(model);
            m_db.SaveChanges();
        }
    }
}