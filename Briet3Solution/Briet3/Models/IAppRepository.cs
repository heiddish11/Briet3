using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Briet3.Models;

namespace Briet3.Models
{
    interface IAppRepository
    {
        //Stating all functions that the system offers
        IEnumerable<Title> GetTitles { get; set; }
        IEnumerable<FileSRT> GetFiles { get; set; }
        FileSRT GetFile(int id);
        void SaveFile(FileSRT model);
    }
}
