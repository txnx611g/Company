using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.IBLL;
using Company.IDAL;
using Company.Model;

/*基类BaseService完成后，我们去完成子类StaffService,添加一个类名称为StaffService
 * ,继承BaseService,实现IStaffService,重写父类的抽象方法,为父类的IBaseDAL属性赋值*/
namespace Company.BLL
{
    public partial class StaffService : BaseService<Staff>, IStaffService
    {
        private IStaffDAL StaffDAL = DALContainer.Container.Resolve<IStaffDAL>();

        public override void SetDal()
        {
            Dal = StaffDAL;
        }
    }
}