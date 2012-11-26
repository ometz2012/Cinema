using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.BLL.Movies
{
 public	class MovieModelBase
	{
	// public Guid MovieID { get; set; } // changed by Marat to "int" because in the database MovieId is a "int".
     public int MovieID { get; set; }
	 public string Tilte { get; set; }

	 public List<Performances.PerformanceModelDTO> Performance { get; set; }
	}
}
