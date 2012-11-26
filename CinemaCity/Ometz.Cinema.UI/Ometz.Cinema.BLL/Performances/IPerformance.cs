using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.BLL.Performances
{
	public interface IPerformance
	{
		//Method that gets all Performances by TheatherId
		IList<PerformanceModelDTO> GetPerformances(Guid theatherId);
	}
}
