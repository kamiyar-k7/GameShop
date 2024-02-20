using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserSide.Home
{
	public class HomeDto
	{
		#region Game
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public float Rating { get; set; }
		public string Trailer { get; set; }
		public List<string> Screenshots { get; set; }
		#endregion
	}
}
