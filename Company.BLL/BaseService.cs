
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Company.IDAL;
/*Company.IBLL,完成后,我们开始完成BLL 选中Company.BLL=>右键=>添加一个类,名称为BaseService，这个类是对IBaseService的具体实现. 
 * 这个类需要调用IDAL接口实例的方法，不知道具体调用哪一个IDAL实例,我这里只有一张Staff表，也就只有一个IStaffDAL的实例,但是如果我们这里有很多表的话，就有很多IDAL接口实例，
 * 这时我们的基类BaseService不知道调用哪一个，但是继承它的子类知道. 所以我们这里把BaseService定义成抽象类,写一个IBaseDAL的属性，再写一个抽象方法
 * 该方法的调用写在 BaseService默认的无参构造函数内,当BaseService创建实例的时候会执行这个抽象方法,然后执行子类重写它的方法 为IBaseDAL属性赋一个具体的IDAL实例对象.*/
namespace Company.BLL
{
    public abstract partial class BaseService<T> where T : class, new()
    {
        public BaseService()
        {
            SetDal();
        }

        public IBaseDAL<T> Dal { get; set; }

        public abstract void SetDal();

        public bool Add(T t)
        {
            Dal.Add(t);
            return Dal.SaveChanges();
        }
        public bool Delete(T t)
        {
            Dal.Delete(t);
            return Dal.SaveChanges();
        }
        public bool Update(T t)
        {
            Dal.Update(t);
            return Dal.SaveChanges();
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetModels(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            return Dal.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }
    }
}