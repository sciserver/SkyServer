﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyServer.Tools.Explore
{
    public class ExplorerQueries
    {

        public string objId;
        public string specId;
        public string fieldId;
        public string apogeeId;
        public string plateId;

        public ExplorerQueries(String objid, String specid, String apogeeid, String fieldid, String plateid) {
            this.objId = objid;
            this.specId = specid;
            this.apogeeId = apogeeid;
            this.fieldId = fieldid;
            this.plateId = plateid;
        }        
        
        ///Left Side panel of the Explore Page
        //photoObj
        public string PhotoObjQuery
        {
            get
            {
                return "select * from PhotoObjAll where objId=" + objId;
            }
        }

        //photoTag
        public string PhotoTagQuery
        {
            get
            {
                return "select * from PhotoTag where objId=" + objId;
            }
        }

        //Field
        public string FieldQuery
        {
            get
            {
                return "select * from Field where fieldId =" + fieldId;
            }            
        }

        //Frame
        public string FrameQuery
        {
            get
            {
                return "select * from Frame where fieldId=" + fieldId;
            }
        }

        //specObjall
        public string SpecObjQuery 
        {
            get
            {
                return "select * from SpecObjAll where specObjId=" + specId;
            }
        }

        //sppLines
        public string sppLinesQuery {
            get
            {
                return   "select * from sppLines where specObjId=" + specId;
            }            
        }

        //sppParams
        public string sppParamsQuery{
            get
            {
                return "select * from sppParams where specObjId=" + specId;
            } 
        }

        //galspec
        public string galSpecLineQuery {
            get
            {
                return "select * from galSpecLine where specObjId=" + specId;
            }
        }

        //galspecIndex
        public string galSpecIndexQuery
        {
            get
            {
                return "select * from galSpecIndx where specObjId=" + specId;
            }
        }

        //galspecInfo
        public string galSpecInfoQuery
        {
            get
            {
                return "select * from galSpecInfo where specObjId=" + specId;
            }
        }

        //stellarMassStarformingPort
        public string stellarMassStarformingPortQuery
        {
            get
            {
                return "select * from stellarMassStarformingPort where specObjId="+specId;
            }
        }


        //stellarMassPassivePort
        public string stellarMassPassivePortQuery
        {
            get
            {
                return "select * from stellarMassPassivePort where specObjId=" + specId ;
            }
        }

        //emissionLinesPort
        public string emissionLinesPortQuery
        {
            get
            {
                return "select * from emissionLinesPort where specObjId=" + specId ;
            }
        }

        //stellarMassPCAWiscBC03
        public string stellarMassPCAWiscBC03Query
        {
            get
            {
                return "select * from stellarMassPCAWiscBC03 where specObjId=" + specId;
            }
        }

        //stellarMassPCAWiscM11
        public string stellarMassPCAWiscM11Query
        {
            get
            {
                return "select * from stellarMassPCAWiscM11 where specObjId=" + specId;
            }
        }

        //For DR10 and above
        //stellarMassFSPSGranEarlyDust
        public string stellarMassFSPSGranEarlyDust
        {
            get
            {
                return "select * from stellarMassFSPSGranEarlyDust where specObjId=" + specId;
            }
        }

        //stellarMassFSPSGranEarlyNoDust
        public string stellarMassFSPSGranEarlyNoDust
        {
            get 
            {
                return "select * from stellarMassFSPSGranEarlyNoDust where specObjId=" + specId;
            }
        }

        //stellarMassFSPSGranWideDust
        public string stellarMassFSPSGranWideDust
        {
            get 
            {
                return "select * from stellarMassFSPSGranWideDust where specObjId=" + specId; 
            }
        }

        //stellarMassFSPSGranWideDust
        public string stellarMassFSPSGranWideNoDust
        {
            get
            {
                return "select * from stellarMassFSPSGranWideNoDust where specObjId=" + specId;
            }
        }

        //apogeeStar
        public string apogeeStar
        {
            get 
            {
                return "select * from apogeeStar where apstar_id=" + apogeeId;
            }
        }

        //aspcapStar
        public string aspcapStar
        {
            get 
            {
                return "select * from aspcapStar where apstar_id="+apogeeId;
            }
        }

        //PhotoZ
        public string PhotoZ{
            get
            {
                //string c1 = "select * from Photoz2 where objid=" + objid;
                return "select * from Photoz where objid=" + objId;
            }
        }

        //PhotzRF
        public string PhotozRF
        {
            get
            {
                return "select * from PhotozRF where objid=" + objId;
                //string c2 = "select * from Photoz2 where objid=" + objid;
            }
        }

        //Plate
        public string Plate {
            get 
            {
                return "select * from PlateX where plateId=" + plateId;
            }
        }

        public string PlateShow {
            get {
                string cmd = " select cast(specObjID as binary(8)) as specObjId," +
                   " fiberId, class as name, str(z,5,3) as z" +
                   " from SpecObjAll where plateID="+plateId+" order by fiberId";
                return cmd;
            }
        }

        //AllSpec Queries
        public string AllSpec1{
            get
            {
               string cmd= "select s.specObjId, s.plate as plate, s.mjd as MJD, s.fiberID as fiber, str(t.ra,10,5) as ra, str(t.dec,10,5) as dec, ";
                cmd += "  str(s.ra,10,5) as specRa, str(s.dec,10,5) as specDec, ";
                cmd += " s.sciencePrimary, str(dbo.fDistanceArcMinEq(t.ra,t.dec,s.ra,s.dec),10,8) as distanceArcMin, ";
                cmd += " s.class as specClass";
                cmd += " from SpecObjAll s, photoobjall t where t.objid=" + objId + " and s.bestobjid=t.objid ";                
                cmd += " order by scienceprimary desc, plate, MJD, fiber";
                return cmd;
            }
        }

        public string AllSpec2 {
            get {
                string cmd = "select s.specObjId, s.plate as plate, s.mjd as MJD, s.fiberID as fiber, str(t.ra,10,5) as ra, str(t.dec,10,5) as dec, ";
                cmd += "  str(s.ra,10,5) as specRa, str(s.dec,10,5) as specDec, ";
                cmd += " s.sciencePrimary, str(dbo.fDistanceArcMinEq(t.ra,t.dec,s.ra,s.dec),10,8) as distanceArcMin, ";
                cmd += " s.class as specClass";
                cmd += " from SpecObjAll s, photoobjall t where t.objid=" + objId + " and s.fluxobjid=t.objid ";
                //cmd += " order by scienceprimary desc, distanceArcMin asc";
                cmd += " order by plate, MJD, fiber ";
                return cmd;
            }
        }
 
        //GalaxyZooQueries
        public string zooSpec {
            get { 
                return "select * from zooSpec where objid="+objId;
            }
        }

        public string galaxyzoo1 {
            get {
                string cmd = "select objid,nvote as 'Votes',str(p_el_debiased,5,3) 'Elliptical proabability (debiased)',";
                cmd += " str(p_cs_debiased,5,3) 'Spiral probability (debiased)'";
                cmd += " from zooSpec where objid=" + objId;
                return cmd;
            }
        }

        public string galaxyzoo2 {
            get {
                string cmd = "select str(p_cw,5,3) as 'Clockwise spiral probability', str(p_acw,5,3) as 'Anticlockwise spiral probability',";
                cmd += " str(p_edge,5,3) as 'Edge-on spiral probablity', str(p_mg,5,3) as 'Merger system probability'";
                cmd += " from zooSpec where objid=" + objId;
                return cmd;
            }
        }

        public string zooNoSpec {
            get {
                string cmd = "select  * from  zooNoSpec where objid = "+objId;
                return cmd;
            }
        }

        public string galaxyZoo3 {
            get {
                string cmd = "select objid,nvote,p_el,p_cs";
                cmd += " from zooNoSpec where objid=" + objId;
                return galaxyZoo3;
            }
        }

        public string zooConfidence
        {
            get {
                return "select * from zooConfidence where objid=" + objId;
            }
        }

        public string zooConfidence2{
            get {
                string cmd = "select objid,f_unclass_clean,f_misclass_clean";
                cmd += " from zooConfidence where objid=" + objId;
                return cmd;
            }
        }

        public string zooMirrorBias
        {
            get {
                return "select * from zooMirrorBias where objid=" + objId;
            }
        }

        public string zooMirrorBias2 {
            get {
                string cmd = "select objid,nvote_mr1,nvote_mr2";
                cmd += " from zooMirrorBias where objid=" + objId;
                return cmd;
            }
        }

        public string zooMonochromeBias
        {
            get {
                return "select * from zooMonochromeBias where objid=" + objId;
            }
        }

        public string zooMonochromeBias2
        {
            get {
                string cmd = "select objid,nvote_mon";
                cmd += " from zooMonochromeBias where objid=" + objId;
                return cmd;
            }
        }

        public string zoo2MainSpecz {
            get {
                return "select * from zoo2MainSpecz where dr8objid=" + objId;
            }
        }

        public string zoo2MainSpecz2 {
            get {
                string cmd = "select dr8objid, total_classifications, total_votes";
                cmd += " from zoo2MainSpecz where dr8objid=" + objId;
                return cmd;

            }
        }

        public string zoo2MainPhotoz
        {
            get {
                return "select * from zoo2MainPhotoz where dr8objid=" + objId;
            }
        }

        public string zoo2MainPhotoz2
        {
            get {
               string  cmd = "select dr8objid, total_classifications, total_votes";
                cmd += " from zoo2MainPhotoz where dr8objid=" + objId;
                return cmd;
            }
        }

        public string zoo2Stripe82Normal
        {
            get {
                return "select * from zoo2Stripe82Normal where dr8objid=" + objId;
            }
        }

        public string zoo2Stripe82Normal2
        {
            get {
                string cmd = "select dr8objid, total_classifications, total_votes";
                cmd += " from zoo2Stripe82Normal where dr8objid=" + objId;
                return cmd;
            }
        }

        public string zoo2Stripe82Coadd1
        {
            get { 
               return "select * from zoo2Stripe82Coadd1 where dr8objid="+objId;
            }
        }

        public string zoo2Stripe82Coadd1_2
        {
            get {
               string cmd = "select dr8objid, total_classifications, total_votes";
                cmd += " from zoo2Stripe82Coadd1 where dr8objid=" + objId;
                return cmd;
            }
        }


        public string zoo2Stripe82Coadd2
        {
            get {
                return "select * from zoo2Stripe82Coadd2 where dr8objid=" + objId;
            }
        }

        public string zoo2Stripe82Coadd2_2
        {
            get {
                string cmd = "select dr8objid, total_classifications, total_votes";
                cmd += " from zoo2Stripe82Coadd2 where dr8objid=" + objId;
                return cmd;
            }
        }

        ///Metadata Queries
        ///
        public String getObjParamaters {
            get{
                string cmd = "select p.ra, p.dec, s.specObjId," +
                       " p.clean, s.survey, cast(p.mode as int), dbo.fPhotoTypeN(p.type) as otype, p.mjd" +
                       " from PhotoObjAll p LEFT OUTER JOIN SpecObjAll s ON s.bestobjid=p.objid AND s.scienceprimary=1" +
                       " where p.objId="+objId;
                return cmd;
            }
        }

        /// <summary>
        /// Imaing Query
        /// </summary>
        /// <param name="objid"></param>
        /// <param name="sdssurl"></param>
        /// <returns></returns>
        public String getImagingQuery(string objid, string sdssurl)
        {
            string flagsLink = sdssurl + "algorithms/photo_flags_recommend.php";
            String iQuery = "";
            iQuery = " select";
            //-- phototag
            iQuery += " dbo.fPhotoFlagsN(pt.flags) as '<a href=" + flagsLink + ">Flags <img src=./images/offsite_black.png /></a>',pt.ra, pt.dec, pt.run, pt.rerun, pt.camcol, pt.field, ";
            iQuery += " cast(pt.fieldId as binary(8)) as fieldId, cast(pt.objId as binary(8)) as objId, ";
            //--PhotoObjall
            iQuery += " pa.clean,  dbo.fPhotoTypeN(pa.type) as otype, ";
            iQuery += " str(pa.u,7,2) as u, str(pa.g,7,2) as g, str(pa.r,7,2) as r, str(pa.i,7,2) as i, str(pa.z,7,2)as z, ";
            iQuery += " str(pa.err_u,7,2) as err_u, str(pa.err_g,7,2) as err_g, str(pa.err_r,7,2) as err_r, str(pa.err_i,7,2) as err_i, str(pa.err_z,7,2) as err_z, ";
            //-- photoObj
            iQuery += " dbo.fPhotoModeN(po.mode) as mode,po.mjd as 'Image MJD',  (po.nDetect-1) as 'Other observations', po.parentID, po.nChild, str(po.extinction_r,7,2) as extinction_r,";
            iQuery += " str(po.petroRad_r,9,2)+' &plusmn; '+str(po.petroRadErr_r,10,3) as 'PetroRad_r (arcmin)',";
            //--- photz,photozRF,zoospec 
            iQuery += " (str(phz.z,7,3)+' &plusmn; '+str(phz.zerr,8,4))as 'photoZ (KD-tree method)', (str(phzrf.z,7,3)+' &plusmn; '+str(phzrf.zerr,8,4)) as 'photoZ (RF method)', ";
            iQuery += " case (1*zz.spiral+10*zz.elliptical+100*zz.uncertain) when 1 then 'Spiral' when 10 then 'Elliptical' when 100 then 'Uncertain' else '-' end as 'Galaxy Zoo 1 morphology' ";
            //all joins
            iQuery += " from PhotoTag pt  ";
            iQuery += " left outer join PhotoObj po on po.objid = pt.objid";
            iQuery += " left outer join Photoz phz on po.objid=phz.objid ";
            iQuery += " left outer join PhotozRF phzrf on po.objid=phzrf.objid ";
            iQuery += " left outer join zooSpec zz on po.objid=zz.objid ";
            iQuery += " left outer join field f on f.fieldID=pt.fieldID ";
            iQuery += " left outer join photoobjall pa with (nolock)on  pa.objid = po.objid ";
            iQuery += " where pt.objId= " + objid;
            return iQuery;
        }

        public string getSpectroQuery(string specid, string objid)
        {
            string iQuery = " select s.plate,s.mjd,fiberid ,s.instrument as 'Spectrograph' ,class, str(z,7,3) as 'Redshift (z)', str(zerr,10,5) as 'Redshift error' ";
            iQuery += " , dbo.fSpecZWarningN(zWarning) as 'Redshift flags'";
            iQuery += " ,s.survey, s.programname, s.scienceprimary as 'primary', (x.nspec-1) as 'Other spec' ";
            iQuery += " ,s.sourcetype, str(velDisp,6,2) as 'Velocity dispersion (km/s)', str(velDispErr,7,3) as 'veldisp_error' ";
            iQuery += " ,case s.survey ";
            iQuery += " WHEN 'sdss' THEN (select(dbo.fPrimtargetN(s.legacy_target1)+' '+dbo.fPrimTargetN(s.legacy_target2)+' '+dbo.fSpecialTarget1N(s.special_target1)))";
            iQuery += " WHEN 'boss' THEN (select str(boss_target1)+','+str(ancillary_target1)+','+str(ancillary_target2))";
            iQuery += " WHEN 'segue1' THEN (select dbo.fSEGUE1target1N(segue1_target1)+','+dbo.fSEGUE1target2N(segue1_target2)) ";
            iQuery += " WHEN 'segue2' THEN (select dbo.fSEGUE2target1N(segue2_target1)+','+ dbo.fSEGUE2target2N(segue2_target2) ) ";
            //iQuery += " --WHEN 'apogee' THEN (select apogee_target1,apogee_target2 ) ";
            iQuery += " ELSE ' No Data ' ";
            iQuery += " END ";
            iQuery += " as targeting_flags ";
            iQuery += " from  PlateX p ,SpecObjAll s ";
            iQuery += " join (select bestobjid, count(*) as nspec from specobjall where bestobjid=" + objid + " group by bestobjid) x on s.bestobjid=x.bestobjid ";
            iQuery += " where p.plateId=s.plateId and  s.specObjId=" + specid;

            return iQuery;
        }

        public String getCrossIdQuery(string whichQuery, string objId)
        {
            String query = "";
            String wiseLink = "";
            switch (whichQuery)
            {
                case "USNO": query = " select 'USNO' as Catalog, str(10*propermotion,6,2)+' &plusmn; '+str(sqrt(power(muraerr,2)+power(mudecerr,2)),8,3) as 'Proper motion (mas/yr)', str(angle,6,3) as 'PM angle (deg E)' from USNO where objId="; break;
                case "FIRST": query = " select 'FIRST' as Catalog, str(peak,8,2)+' &plusmn; '+str(rms,8,2) as 'Peak flux (mJy)', major as 'Major axis (arcsec)', minor as 'Minor axis (arcsec)' from First where objId="; break;
                case "ROSAT": query = " select 'ROSAT' as Catalog, cps, hr1, hr2, ext from ROSAT where objId="; break;
                case "RC3": query = " select 'RC3' as Catalog, hubble as 'Hubble type', str(m21,5,2)+' &plusmn; '+str(m21err,6,3) as '21 cm magnitude', hi as 'Neutral Hydrogen Index' from RC3 where objId="; break;
                case "WISE": query = " select 'WISE' as Catalog,w.w1mag,w.w2mag,w.w3mag,w.w4mag,'<a href=''" + wiseLink + "''>Link</a>' as 'Full WISE data' from WISE_xmatch x join WISE_allsky w on x.wise_cntr=w.cntr where x.sdss_objid="; break;
                case "2MASS": query = " select '2MASS' as Catalog, str(j,7,3) as 'J', h as 'H', k as 'K_s', phQual from TwoMASS where objId="; break;
                default: break;
            }
            query += objId;

            return query;
        }

        public string USNO {
            get
            {
                string cmd = " select 'USNO' as Catalog, str(10*propermotion,6,2)+' &plusmn; '+str(sqrt(power(muraerr,2)+power(mudecerr,2)),8,3) as 'Proper motion (mas/yr)', ";
                       cmd += " angle as 'PM angle (deg E)' from USNO where objId="+objId;
                return cmd;
            }
        }

        public string FIRST{
            get{
                string cmd = " select 'FIRST' as Catalog, str(peak,8,2)+' &plusmn; '+str(rms,8,2) as 'Peak flux (mJy)', major as 'Major axis (arcsec)', ";
                       cmd += " minor as 'Minor axis (arcsec)' from First where objId="+objId;
                return cmd;
            }
        }

        public string ROSAT {
            get{
                string cmd = " select 'ROSAT' as Catalog, cps, hr1, hr2, ext from ROSAT where objId="+objId;
                return cmd;
            }
        }

        public string RC3 {
            get
            {
                string cmd = " select 'RC3' as Catalog, hubble as 'Hubble type', str(m21,5,2)+' &plusmn; '+str(m21err,6,3) as '21 cm magnitude', ";
                       cmd += " hi as 'Neutral Hydrogen Index' from RC3 where objId="+objId;
                return cmd;
            }
        }

        public string WISE {
            get
            {
                string cmd = " select 'WISE' as Catalog,w.w1mag,w.w2mag,w.w3mag,w.w4mag,'<a href=''@wiseLink''>Link</a>' as 'Full WISE data' ";
                       cmd += " from WISE_xmatch x join WISE_allsky w on x.wise_cntr=w.cntr where x.sdss_objid="+objId;
                       cmd = cmd.Replace("@wiselink", wiseLinkCrossId);
                      
                return cmd;
            }
        }

        public string TWOMASS {
            get
            {
                //string cmd = " select '2MASS' as Catalog, str(j,7,3) as 'J', h as 'H', k as 'K_s', phQual from TwoMASS where objId=" + objId;
                string cmd = " select '2MASS' as Catalog, j as 'J', h as 'H', k as 'K_s', phQual from TwoMASS where objId=" + objId;
                return cmd;
            }
        }

        public string wiseLinkCrossId {
            get {
                string cmd = "select * from wise_xmatch x join wise_allsky a on x.wise_cntr=a.cntr where x.sdss_objid="+objId+"&name=WISE_allsky"+"id="+objId;
                return cmd;
            }
        }




        //public enum queryType
        //{
        //    PhotObj, PhotoTag, PhotoZ, PhotozRF,Field, Frame,
        //    SpecObj, sppLines, sppParams,
        //    galSpec, galSpecLine,galSpecIndex,galSpecInfo,
        //    stellarMassStarformingPort, stellarMassPassivePort,
        //    emissionLines, stellarMassPCAWiscBC03, stellarMassPCAWiscM11,
        //    stellarMassFSPSGranEarlyDust, stellarMassFSPSGranEarlyNoDust,
        //    stellarMassFSPSGranWideDust, apogeeStar, aspcapStar
        //};

        //// Apogee Queries
        /* Queries */
        public string APOGEE_BASE_QUERY = @"select
  a.ra, 
  a.dec,
  a.apstar_id, 
  a.apogee_id, 
  a.glon, 
  a.glat, 
  a.location_id,
  a.commiss,
  a.vhelio_avg, 
  a.vscatter, 

  b.teff, 
  b.teff_err,
  b.logg, 
  b.logg_err,
  b.metals, 
  b.metals_err,  
  b.alphafe, 
  b.alphafe_err,

  c.j,
  c.h,
  c.k,
  c.j_err,
  c.h_err,
  c.k_err,
  case c.src_4_5 
    when 'none' then NULL 
    when 'WISE' then c.wise_4_5 
    when 'IRAC' then c.irac_4_5 
    end 
    as mag_4_5,
  case c.src_4_5 
    when 'none' then NULL 
    when 'WISE' then c.wise_4_5_err 
    when 'IRAC' then c.irac_4_5_err 
    end 
    as mag_4_5_err,
  c.src_4_5,

  dbo.fApogeeTarget1N(a.apogee_target1) as apogeeTarget1N,
  dbo.fApogeeTarget2N(a.apogee_target2) as apogeeTarget2N,
  dbo.fApogeeStarFlagN(a.starflag) as apogeeStarFlagN,
  dbo.fApogeeAspcapFlagN(aspcapflag) as apogeeAspcapFlagN

from apogeeStar a
join aspcapStar b on a.apstar_id = b.apstar_id
join apogeeObject c on a.apogee_id = c.apogee_id
";

    }
}
