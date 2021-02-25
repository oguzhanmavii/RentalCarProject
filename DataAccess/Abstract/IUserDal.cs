using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    interface IUserDal:IEntityRepository<User>
    {
    }
}
