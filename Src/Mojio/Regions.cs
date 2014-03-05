using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Regions
    /// </summary>
    public class Regions
    {
        /// <summary>Gets or sets the countries.</summary>
        /// <value>The countries.</value>
        public static Dictionary<string, string> Countries { get; set; }

        /// <summary>Gets or sets the provinces.</summary>
        /// <value>The provinces.</value>
        public static Dictionary<string, Dictionary<string, string>> Provinces { get; set; }

        /// <summary>USA</summary>
        public const string USA = "US";
        /// <summary>Canada</summary>
        public const string Canada = "CA";

        static Regions()
        {
            Countries = new Dictionary<string, string>();
            Countries.Add(USA, "United States");
            Countries.Add(Canada, "Canada");

            Provinces = new Dictionary<string, Dictionary<string, string>>();
            var usStates = new Dictionary<string, string>();
            var caProvinces = new Dictionary<string, string>();

            Provinces.Add(USA, usStates);
            Provinces.Add(Canada, caProvinces);

            usStates.Add("AL", "Alabama");
            usStates.Add("AK", "Alaska");
            usStates.Add("AZ", "Arizona");
            usStates.Add("AR", "Arkansas");
            usStates.Add("CA", "California");
            usStates.Add("CO", "Colorado");
            usStates.Add("CT", "Connecticut");
            usStates.Add("DE", "Delaware");
            usStates.Add("DC", "District of Columbia");
            usStates.Add("FL", "Florida");
            usStates.Add("GA", "Georgia");
            usStates.Add("HI", "Hawaii");
            usStates.Add("ID", "Idaho");
            usStates.Add("IL", "Illinois");
            usStates.Add("IN", "Indiana");
            usStates.Add("IA", "Iowa");
            usStates.Add("KS", "Kansas");
            usStates.Add("KY", "Kentucky");
            usStates.Add("LA", "Louisiana");
            usStates.Add("ME", "Maine");
            usStates.Add("MD", "Maryland");
            usStates.Add("MA", "Massachusetts");
            usStates.Add("MI", "Michigan");
            usStates.Add("MN", "Minnesota");
            usStates.Add("MS", "Mississippi");
            usStates.Add("MO", "Missouri");
            usStates.Add("MT", "Montana");
            usStates.Add("NE", "Nebraska");
            usStates.Add("NV", "Nevada");
            usStates.Add("NH", "New Hampshire");
            usStates.Add("NJ", "New Jersey");
            usStates.Add("NM", "New Mexico");
            usStates.Add("NY", "New York");
            usStates.Add("NC", "North Carolina");
            usStates.Add("ND", "North Dakota");
            usStates.Add("OH", "Ohio");
            usStates.Add("OK", "Oklahoma");
            usStates.Add("OR", "Oregon");
            usStates.Add("PA", "Pennsylvania");
            usStates.Add("RI", "Rhode Island");
            usStates.Add("SC", "Douth Carolina");
            usStates.Add("SD", "Douth Dakota");
            usStates.Add("TN", "Tennessee");
            usStates.Add("TX", "Texas");
            usStates.Add("UT", "Utah");
            usStates.Add("VT", "Vermont");
            usStates.Add("VA", "Virginia");
            usStates.Add("WA", "Washington");
            usStates.Add("WV", "West Virginia");
            usStates.Add("WI", "Wisconsin");
            usStates.Add("WY", "Wyoming");

            caProvinces.Add("AB", "Alberta");
            caProvinces.Add("BC", "British Columbia");
            caProvinces.Add("MB", "Manitoba");
            caProvinces.Add("NB", "New Brunswick");
            caProvinces.Add("NL", "Newfoundland & Labrador");
            caProvinces.Add("NT", "Northwest Territories");
            caProvinces.Add("NS", "Nova Scotia");
            caProvinces.Add("NU", "Nunavut");
            caProvinces.Add("ON", "Ontario");
            caProvinces.Add("PE", "Prince Edward Island");
            caProvinces.Add("QC", "Quebec");
            caProvinces.Add("SK", "Saskatchewan");
            caProvinces.Add("YT", "Yukon");
        }
    }

}
