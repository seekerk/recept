namespace Recept2
{
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// счетчик элементов форм
    /// </summary>
    class FormCounter
    {
        /// <summary>
        /// Значение верхнего уровня
        /// </summary>
        int count1;
        
        /// <summary>
        /// Значение второго уровня
        /// </summary>
        int count2;
        
        public FormCounter()
        {
            
        }
        
        /// <summary>
        /// Получение следующего значения счетчика
        /// </summary>
        /// <returns></returns>
        public string next()
        {
            count2++;
            return count1.ToString(CultureInfo.CurrentCulture) + "." + count2.ToString(CultureInfo.CurrentCulture) + ".";
        }
        
        /// <summary>
        /// Увеличение значения головного счетчика
        /// </summary>
        /// <returns></returns>
        public string moveUp()
        {
            count2 = 0;
            count1++;
            return count1.ToString(CultureInfo.CurrentCulture) + ".";
        }
    }
}
