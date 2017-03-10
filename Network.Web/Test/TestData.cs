using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Network.Web.Test
{
    public class TestData
    {
        private Guid testGuid = Guid.NewGuid();
       // static string nameGuid = testGuid.ToString().Substring(0, 4);
       //test person
        public Person Person()
        {
            
                return new Person()
                {
                  //  PersonDescription = "Test Person",
                    PersonId = testGuid,
                    PersonName = "Person" + testGuid.ToString().Substring(0, 5),
                    PersonPhone = "123456789",
                    PersonPosition = "Cu li cao cap",
                //    PersonType = Network.Domain.Enum.EType.PersonEnum.CBAMC,

                };
            
        }
        //test partner
        public Partner Partner(Person p)
        {
            return new Partner()
            {
                PartnerId = testGuid,
              //  PersonId = p.PersonId,
                PartnerName = "Partner" + testGuid.ToString().Substring(0, 5),
                PartnerPhone = "1234567899",

            };
            
        }
    }
}