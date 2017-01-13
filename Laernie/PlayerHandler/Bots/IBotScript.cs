using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laernie
{
    interface IBotScript
    {
        /// <summary>
        /// Wird einmalig beim erstellen aufgerufen.
        /// </summary>
        void Initialize();
        /// <summary>
        /// Wird aufgerufen, wenn der Bot auf einer Plattform steht und der nächste Input erwartet wird.
        /// </summary>
        /// <param name="bot">Referenz zum Bot.</param>
        /// <returns></returns>
        MoveInformation Think(IBot bot);

        /// <summary>
        /// Wird aufgerufen, wenn der Bot sich in der Luft(fliegt) befindet.
        /// </summary>
        /// <param name="bot"></param>
        void OnFly(IBot bot);

        /// <summary>
        /// Wird aufgerufen, wenn der Bot "stirbt".
        /// Außerhalb der Karte.
        /// </summary>
        /// <param name="bot"></param>
        void OnDead(IBot bot);

        /// <summary>
        /// Wird aufgerufen, wenn der Bot sicher gelandet ist.
        /// </summary>
        /// <param name="bot"></param>
        void OnReachPlattform(IBot bot);
        string ToString();
    }
}
