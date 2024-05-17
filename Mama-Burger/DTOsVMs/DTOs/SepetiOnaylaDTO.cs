using MamaBurger.Classes.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MamaBurger.DTOsVMs.DTOs
{
	public class SepetiOnaylaDTO
	{
        public ICollection<Sepet> Sepettekiler { get; set; }
        public int UserID { get; set; }
	}
}
