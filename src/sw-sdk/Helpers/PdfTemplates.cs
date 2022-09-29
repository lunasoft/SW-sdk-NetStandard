﻿using System;
using System.Collections.Generic;
using System.Text;

namespace sw_sdk.Helpers
{
    /// <summary>
    /// Plantillas para la generación de PDF.
    /// </summary>
    public enum PdfTemplates
    {
        /// <summary>
        /// CFDI 3.3
        /// </summary>
        cfdi33,
        /// <summary>
        /// CFDI 4.0
        /// </summary>
        cfdi40,
        /// <summary>
        /// Pagos 1.0
        /// </summary>
        payment,
        /// <summary>
        /// Pagos 2.0
        /// </summary>
        payment20,
        /// <summary>
        /// Nómina Rev. B
        /// </summary>
        payroll,
        /// <summary>
        /// Nómina Rev. C
        /// </summary>
        payroll40,
        /// <summary>
        /// Carta Porte 2.0 CFDI 3.3
        /// </summary>
        billoflading20,
        /// <summary>
        /// Carta Porte 2.0 CFDI 4.0
        /// </summary>
        billoflading40
    }
}
