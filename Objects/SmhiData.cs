using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldServer
{
   
        public class SmhiData {
            public string validTime {get;set;}
            public List<SmhiParameter> parameters{get;set;}

            private decimal? GetDecimal(string name) {

                var value = parameters?.FirstOrDefault(
                        x => x.name == name)?.values?.FirstOrDefault()?.ToString();
                        
                        if(string.IsNullOrEmpty(value)) {
                            return null;
                        }
                        return decimal.Parse(value);
            }

                public int  Hour  => DateTime.Parse(validTime).Hour;
                public decimal? Temperature  => GetDecimal("t");
                public decimal? Rain  => GetDecimal("pmax");
        }


       
    
}
