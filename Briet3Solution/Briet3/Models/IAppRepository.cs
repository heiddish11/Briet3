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
        //Yfirlysing a follum sem vid viljum bjoda upp a
        IEnumerable<Title> GetTitles { get; set; }
        IEnumerable<FileSRT> GetFiles { get; set; }

        //Foll sem leyfa okkur ad setja inn breytur
        //void AddTitle(Title t);


        //Fall sem leyfir okkur ad vista
        //void Save();
    }
}
