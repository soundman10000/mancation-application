using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Team
{
    public class Team
    {
        public Team(List<Guid> users)
        {
            this.Users = users;
        }

        public List<Guid> Users { get; }
    }
}
