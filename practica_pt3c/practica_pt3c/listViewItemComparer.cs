using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista
{
    // Esta clase sirve para ordenar una tabla al hacer click en una columna de la tabla
    class listViewItemComparer : IComparer
    {
        public int col;
        public SortOrder order;

        public  listViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }

        public listViewItemComparer(int column, SortOrder order)
        {

            col = column;
            this.order = order;
        }


        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                       ((ListViewItem)y).SubItems[col].Text);

            // Si el orden de ordenación es Ascendente, invierte el valor de retorno
            if (order == SortOrder.Ascending)
            {
                returnVal *= -1;
            }
            return returnVal;
        }

    }
}
