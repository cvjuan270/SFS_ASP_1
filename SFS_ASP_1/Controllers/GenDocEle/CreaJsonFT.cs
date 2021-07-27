﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SFS_ASP_1.Models.Factura;
using SFS_ASP_1.Models;
using System.Data;
using Newtonsoft.Json;

namespace SFS_ASP_1.Controllers.GenDocEle
{
    public class CreaJsonFT
    {
        private static Cabecera cabecera = new Cabecera();
        private static  AdicionalCabecera adicionalCabecera = new AdicionalCabecera();
        private static List<Detalle> odetalle = new List<Detalle>();
        private static List<Leyenda> leyendas = new List<Leyenda>();
        private static List<Tributo> tributos = new List<Tributo>();
        private static RootFT rootFT;
        public static string JsonFT;
        public static string _CreaJsonFT(int DocEnt) 
        {
            rootFT = null;
           rootFT= GetDocumentoElectronico(DocEnt);
           return JsonFT = JsonConvert.SerializeObject(rootFT, Formatting.Indented);
        }

        public static RootFT GetDocumentoElectronico(int DocEntry)
        {

            RootFT root = new RootFT
            {
                cabecera = GetCabecera(DocEntry),
                detalle = GetListDetalle(DocEntry),
                leyendas = GetLeyenda(DocEntry),
                tributos = GetTributo(DocEntry)
            };
            return root;
        }

        public static Cabecera GetCabecera(int DocEntry)
        {
            using (DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC[dbo].[Consulta_SFS_CAB] @DocEntry = '{0}'", DocEntry)))
            {
                cabecera.tipOperacion = dt.Rows[0].ItemArray[0].ToString();
                cabecera.fecEmision = dt.Rows[0].ItemArray[1].ToString();
                cabecera.horEmision = dt.Rows[0].ItemArray[2].ToString();
                cabecera.fecVencimiento = dt.Rows[0].ItemArray[3].ToString();
                cabecera.codLocalEmisor = dt.Rows[0].ItemArray[4].ToString();
                cabecera.tipDocUsuario = dt.Rows[0].ItemArray[5].ToString();
                cabecera.numDocUsuario = dt.Rows[0].ItemArray[6].ToString();
                cabecera.rznSocialUsuario = dt.Rows[0].ItemArray[7].ToString();
                cabecera.tipMoneda = dt.Rows[0].ItemArray[8].ToString();
                cabecera.sumTotTributos = dt.Rows[0].ItemArray[9].ToString();
                cabecera.sumTotValVenta = dt.Rows[0].ItemArray[10].ToString();
                cabecera.sumPrecioVenta = dt.Rows[0].ItemArray[11].ToString();
                cabecera.sumDescTotal = dt.Rows[0].ItemArray[12].ToString();
                cabecera.sumOtrosCargos = dt.Rows[0].ItemArray[13].ToString();
                cabecera.sumTotalAnticipos = dt.Rows[0].ItemArray[14].ToString();
                cabecera.sumImpVenta = dt.Rows[0].ItemArray[15].ToString();
                cabecera.ublVersionId = dt.Rows[0].ItemArray[16].ToString();
                cabecera.customizationId = dt.Rows[0].ItemArray[17].ToString();
                cabecera.adicionalCabecera = GetAditionalCabecera(DocEntry);
            }
            return cabecera;
        }
        public static AdicionalCabecera GetAditionalCabecera(int DocEntry)
        {
            using (DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC  [dbo].[Consulta_SFS_ACA] @DocEntry = '{0}'", DocEntry)))
            {
                adicionalCabecera.ctaBancoNacionDetraccion = dt.Rows[0].ItemArray[0].ToString();
                adicionalCabecera.codBienDetraccion = dt.Rows[0].ItemArray[1].ToString();
                adicionalCabecera.porDetraccion = dt.Rows[0].ItemArray[2].ToString();
                adicionalCabecera.mtoDetraccion = dt.Rows[0].ItemArray[3].ToString();
                adicionalCabecera.codMedioPago = dt.Rows[0].ItemArray[4].ToString();
                adicionalCabecera.codPaisCliente = dt.Rows[0].ItemArray[5].ToString();
                adicionalCabecera.codUbigeoCliente = dt.Rows[0].ItemArray[6].ToString();
                adicionalCabecera.desDireccionCliente = dt.Rows[0].ItemArray[7].ToString();
                adicionalCabecera.codPaisEntrega = dt.Rows[0].ItemArray[8].ToString();
                adicionalCabecera.codUbigeoEntrega = dt.Rows[0].ItemArray[9].ToString();
                adicionalCabecera.desDireccionEntrega = dt.Rows[0].ItemArray[10].ToString();
            }

            return adicionalCabecera;
        }
        public static List<Detalle> GetListDetalle(int DocEntry)
        {
            using (DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC [dbo].[Consulta_SFS_DET] @DocEntry = '{0}'", DocEntry)))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Detalle detalle = new Detalle();
                    detalle.codUnidadMedida = dt.Rows[i].ItemArray[0].ToString();
                    detalle.codUnidadMedida = dt.Rows[i].ItemArray[0].ToString();
                    detalle.ctdUnidadItem = dt.Rows[i].ItemArray[1].ToString();
                    detalle.codProducto = dt.Rows[i].ItemArray[2].ToString();
                    detalle.codProductoSUNAT = dt.Rows[i].ItemArray[3].ToString();
                    detalle.desItem = dt.Rows[i].ItemArray[4].ToString();
                    detalle.mtoValorUnitario = dt.Rows[i].ItemArray[5].ToString();
                    detalle.sumTotTributosItem = dt.Rows[i].ItemArray[6].ToString();
                    detalle.codTriIGV = dt.Rows[i].ItemArray[7].ToString();
                    detalle.mtoIgvItem = dt.Rows[i].ItemArray[8].ToString();
                    detalle.mtoBaseIgvItem = dt.Rows[i].ItemArray[9].ToString();
                    detalle.nomTributoIgvItem = dt.Rows[i].ItemArray[10].ToString();
                    detalle.codTipTributoIgvItem = dt.Rows[i].ItemArray[11].ToString();
                    detalle.tipAfeIGV = dt.Rows[i].ItemArray[12].ToString();
                    detalle.porIgvItem = dt.Rows[i].ItemArray[13].ToString();
                    detalle.codTriISC = dt.Rows[i].ItemArray[14].ToString();
                    detalle.mtoIscItem = dt.Rows[i].ItemArray[15].ToString();
                    detalle.mtoBaseIscItem = dt.Rows[i].ItemArray[16].ToString();
                    detalle.nomTributoIscItem = dt.Rows[i].ItemArray[17].ToString();
                    detalle.codTipTributoIscItem = dt.Rows[i].ItemArray[18].ToString();
                    detalle.tipSisISC = dt.Rows[i].ItemArray[19].ToString();
                    detalle.porIscItem = dt.Rows[i].ItemArray[20].ToString();
                    detalle.codTriOtro = dt.Rows[i].ItemArray[21].ToString();
                    detalle.mtoTriOtroItem = dt.Rows[i].ItemArray[22].ToString();
                    detalle.mtoBaseTriOtroItem = dt.Rows[i].ItemArray[23].ToString();
                    detalle.nomTributoOtroItem = dt.Rows[i].ItemArray[24].ToString();
                    detalle.codTipTributoOtroItem = dt.Rows[i].ItemArray[25].ToString();
                    detalle.porTriOtroItem = dt.Rows[i].ItemArray[26].ToString();
                    detalle.codTriIcbper = dt.Rows[i].ItemArray[27].ToString();
                    detalle.mtoTriIcbperItem = dt.Rows[i].ItemArray[28].ToString();
                    detalle.ctdBolsasTriIcbperItem = dt.Rows[i].ItemArray[29].ToString();
                    detalle.nomTributoIcbperItem = dt.Rows[i].ItemArray[30].ToString();
                    detalle.codTipTributoIcbperItem = dt.Rows[i].ItemArray[31].ToString();
                    detalle.mtoTriIcbperUnidad = dt.Rows[i].ItemArray[32].ToString();
                    detalle.mtoPrecioVentaUnitario = dt.Rows[i].ItemArray[33].ToString();
                    detalle.mtoValorVentaItem = dt.Rows[i].ItemArray[34].ToString();
                    detalle.mtoValorReferencialUnitario = dt.Rows[i].ItemArray[35].ToString();
                    odetalle.Add(detalle);
                }  
            }

            return odetalle;
        }
        public static List<Leyenda> GetLeyenda(int DocEntry)
        {
            using (DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC [dbo].[Consulta_SFS_LEY] @DocEntry = '{0}'", DocEntry)))
            {
                Leyenda leyenda = new Leyenda();

                leyenda.codLeyenda = dt.Rows[0].ItemArray[0].ToString();
                leyenda.desLeyenda = dt.Rows[0].ItemArray[1].ToString();

                leyendas.Add(leyenda);
            }
            return leyendas;
        }
        public static List<Tributo> GetTributo(int DocEntry)
        {
            using (DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC  [dbo].[Consulta_SFS_TRY] @DocEntry = '{0}'", DocEntry)))
            {
                Tributo tributo = new Tributo();

                tributo.ideTributo = dt.Rows[0].ItemArray[0].ToString();
                tributo.nomTributo = dt.Rows[0].ItemArray[1].ToString();
                tributo.codTipTributo = dt.Rows[0].ItemArray[2].ToString();
                tributo.mtoBaseImponible = dt.Rows[0].ItemArray[3].ToString();
                tributo.mtoTributo = dt.Rows[0].ItemArray[4].ToString();

                tributos.Add(tributo);
            }

            return tributos;
        }

    }
}