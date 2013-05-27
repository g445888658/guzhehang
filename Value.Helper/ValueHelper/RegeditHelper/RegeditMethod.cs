using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ValueHelper.RegeditHelper
{
    public class RegistryHelper
    {
        /// <summary>
        /// 创建子键的方法
        /// </summary>
        /// <param name="sunbkey">参数sunbkey表示要创建的子键的名称或路径名。创建成功返回被创建的子键，否则返回null</param>
        /// <returns></returns>
        public RegistryKey CreateSubKey(String sunbkey)
        {
            return null;
        }

        /// <summary>
        /// 打开子键的方法
        /// </summary>
        /// <param name="name">参数name表示要打开的子键名或其路径名，参数writable表示被打开的子键是否允许被修改，第一个方法打开的子键是只读的</param>
        /// <returns></returns>
        public RegistryKey OpenSubKey(String name)
        {
            return null;
        }

        /// <summary>
        /// 打开子键的方法
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RegistryKey OpenSubKey(string name, bool writable)
        {
            return null;
        }

        /// <summary>
        /// Microsoft.Win32类还为我们提供了另一个方法，用于打开远程计算机上的注册表
        /// </summary>
        /// <param name="hKey"></param>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public static RegistryKey OpenRemoteBaseKey(RegistryHive hKey, string machineName)
        {
            return null;
        }

        /// <summary>
        /// 该方法用于删除指定的主键。如果要删除的子键还包含主键则删除失败，并返回一个异常
        /// </summary>
        /// <param name="subkey"></param>
        public void DeleteKey(string subkey)
        {

        }

        /// <summary>
        /// 如果要彻底删除该子键极其目录下的子键可以用方法DeleteSubKeyTree
        /// </summary>
        /// <param name="subkey"></param>
        public void DeleteKeyTree(string subkey)
        { 
            
        }

        /// <summary>
        /// 读取键值的方法
        /// </summary>
        /// <param name="name">参数name表示键的名称，返回类型是一个object类型，如果指定的键不存在则返回null</param>
        /// <returns></returns>
        public object GetValue(string name) 
        {
            return null;
        }

        /// <summary>
        /// 如果失败又不希望返回的值是null则可以指定参数defaultValue，指定了参数则在读取失败的情况下返回该参数指定的值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public object GetValue(string name, object defaultValue)
        {
            return null;
        }

        /// <summary>
        /// 设置键值的方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object SetValue(string name, object value)
        {
            return null;
        }
 





 


 


 





    }
}
