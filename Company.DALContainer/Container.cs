
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL;
using Company.IDAL;

/*StaffDAL完成后，我们要完成的是DALContainer,该类库主要是创建IDAL的实例对象,我们这里可以自己写一个工厂也可以通过一些第三方的IOC框架,这里使用Autofac 
 * 1.选中DALContainer=>右键=>管理Nuget程序包=>搜索Autofac=>下载安装对应,net版本的AutoFac 
 * 2.安装完成后,我们在DALContainer下添加一个名为Container的类.*/
namespace Company.DALContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取 IDal 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }

            return container.Resolve<T>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<StaffDAL>().As<IStaffDAL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}