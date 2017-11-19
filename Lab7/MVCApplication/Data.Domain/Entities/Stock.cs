using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace Entities
{
        public class Stock
        {
            
            public Stock() { }

            [Required]
            public Guid Id { get;  set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int Code { get; set; }

            

            public static Stock Create(Guid id,string name, int code)
            {
                var instance = new Stock();
                instance.Update(id, name, code);
                return instance;
            }

            public void Update(Guid id, string name, int code)
            {
                Name = name;
                Code = code;
                
            }
        }
    

}
