using Sonluk.DAFactory;
using Sonluk.Entities.Account;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.CRM;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class SY_LANGUAGE_RETURN
    {
        private static readonly ISY_LANGUAGE_RETURN data_ISY_LANGUAGE_RETURN = MESDataAccess.CreateISY_LANGUAGE_RETURN();
        private static readonly ICRM_Login data_ICRM_Login = RMSDataAccess.CreateCRM_Login();
        public MES_RETURN INSERT(MES_SY_LANGUAGE_RETURN model)
        {
            return data_ISY_LANGUAGE_RETURN.INSERT(model);
        }
        public MES_RETURN UPDATE(MES_SY_LANGUAGE_RETURN model)
        {
            return data_ISY_LANGUAGE_RETURN.UPDATE(model);
        }
        public MES_SY_LANGUAGE_RETURN_SELECT SELECT(MES_SY_LANGUAGE_RETURN model)
        {
            return data_ISY_LANGUAGE_RETURN.SELECT(model);
        }
        public MES_RETURN RETURNMX_INSERT(MES_SY_LANGUAGE_RETURNMX model)
        {
            return data_ISY_LANGUAGE_RETURN.RETURNMX_INSERT(model);
        }
        public MES_SY_LANGUAGE_RETURNMX_SELECT RETURNMX_SELECT(MES_SY_LANGUAGE_RETURNMX model)
        {
            return data_ISY_LANGUAGE_RETURN.RETURNMX_SELECT(model);
        }
        public MES_RETURN RETURNMX_UPDATE(MES_SY_LANGUAGE_RETURNMX model)
        {
            return data_ISY_LANGUAGE_RETURN.RETURNMX_UPDATE(model);
        }
        public MES_RETURN RETURN_MESSAGE(MES_RETURN model, string ptoken)
        {
            TokenInfo rst_TokenInfo = data_ICRM_Login.get_ptokeninfo_language(ptoken);
            if (model.ISCLMSG == 0 && !string.IsNullOrEmpty(model.MESSAGE) && rst_TokenInfo.LANGUAGEID > 0)
            {
                MES_RETURN rst = new MES_RETURN();
                //TokenInfo rst_TokenInfo = data_ICRM_Login.get_ptokeninfo_language(ptoken);
                MES_SY_LANGUAGE_RETURN model_MES_SY_LANGUAGE_RETURN = new MES_SY_LANGUAGE_RETURN();
                model_MES_SY_LANGUAGE_RETURN.MSGNO = model.MSGNO;
                model_MES_SY_LANGUAGE_RETURN.MSGNAME = model.MESSAGE;
                model_MES_SY_LANGUAGE_RETURN.LB = 1;
                MES_SY_LANGUAGE_RETURN_SELECT rst_MES_SY_LANGUAGE_RETURN_SELECT = data_ISY_LANGUAGE_RETURN.SELECT(model_MES_SY_LANGUAGE_RETURN);
                if (rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_RETURN.TYPE != "S")
                {
                    return rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_RETURN;
                }
                if (rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN.Count > 0)
                {
                    MES_SY_LANGUAGE_RETURNMX model_MES_SY_LANGUAGE_RETURNMX = new MES_SY_LANGUAGE_RETURNMX();
                    model_MES_SY_LANGUAGE_RETURNMX.MSGID = rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGID;
                    model_MES_SY_LANGUAGE_RETURNMX.SYLANGUAGEID = rst_TokenInfo.LANGUAGEID;
                    model_MES_SY_LANGUAGE_RETURNMX.LB = 1;
                    MES_SY_LANGUAGE_RETURNMX_SELECT rst_MES_SY_LANGUAGE_RETURNMX_SELECT = data_ISY_LANGUAGE_RETURN.RETURNMX_SELECT(model_MES_SY_LANGUAGE_RETURNMX);
                    if (rst_MES_SY_LANGUAGE_RETURNMX_SELECT.MES_RETURN.TYPE != "S")
                    {
                        return rst_MES_SY_LANGUAGE_RETURNMX_SELECT.MES_RETURN;
                    }
                    if (rst_MES_SY_LANGUAGE_RETURNMX_SELECT.MES_SY_LANGUAGE_RETURNMX.Count > 0)
                    {
                        rst.TYPE = model.TYPE;
                        if (!string.IsNullOrEmpty(rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGNO))
                        {
                            rst.MESSAGE = rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGNO + "-" + rst_MES_SY_LANGUAGE_RETURNMX_SELECT.MES_SY_LANGUAGE_RETURNMX[0].MSGMXTEXT;
                        }
                        else
                        {
                            rst.MESSAGE = rst_MES_SY_LANGUAGE_RETURNMX_SELECT.MES_SY_LANGUAGE_RETURNMX[0].MSGMXTEXT;
                        }
                    }
                    else
                    {
                        model_MES_SY_LANGUAGE_RETURNMX = new MES_SY_LANGUAGE_RETURNMX();
                        model_MES_SY_LANGUAGE_RETURNMX.MSGID = rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGID;
                        model_MES_SY_LANGUAGE_RETURNMX.SYLANGUAGEID = rst_TokenInfo.LANGUAGEID;
                        model_MES_SY_LANGUAGE_RETURNMX.MSGMXTEXT = rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGNAME;
                        model_MES_SY_LANGUAGE_RETURNMX.CJRID = rst_TokenInfo.STAFFID;
                        rst = data_ISY_LANGUAGE_RETURN.RETURNMX_INSERT(model_MES_SY_LANGUAGE_RETURNMX);
                        if (rst.TYPE != "S")
                        {
                            return rst;
                        }
                        rst.TYPE = model.TYPE;
                        if (!string.IsNullOrEmpty(rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGNO))
                        {
                            rst.MESSAGE = rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGNO + "-" + rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGNAME;
                        }
                        else
                        {
                            rst.MESSAGE = rst_MES_SY_LANGUAGE_RETURN_SELECT.MES_SY_LANGUAGE_RETURN[0].MSGNAME;
                        }
                    }
                }
                else
                {
                    model_MES_SY_LANGUAGE_RETURN = new MES_SY_LANGUAGE_RETURN();
                    if (!string.IsNullOrEmpty(model.MSGNO))
                    {
                        model_MES_SY_LANGUAGE_RETURN.MSGNO = model.MSGNO;
                        model_MES_SY_LANGUAGE_RETURN.MSGNAME = model.MSGNO;
                    }
                    else
                    {
                        model_MES_SY_LANGUAGE_RETURN.MSGNO = "";
                        model_MES_SY_LANGUAGE_RETURN.MSGNAME = model.MESSAGE;
                    }
                    model_MES_SY_LANGUAGE_RETURN.MSGREMARK = "";
                    model_MES_SY_LANGUAGE_RETURN.CJRID = rst_TokenInfo.STAFFID;
                    rst = data_ISY_LANGUAGE_RETURN.INSERT(model_MES_SY_LANGUAGE_RETURN);
                    if (rst.TYPE != "S")
                    {
                        return rst;
                    }
                    MES_SY_LANGUAGE_RETURNMX model_MES_SY_LANGUAGE_RETURNMX = new MES_SY_LANGUAGE_RETURNMX();
                    model_MES_SY_LANGUAGE_RETURNMX.MSGID = rst.TID;
                    model_MES_SY_LANGUAGE_RETURNMX.SYLANGUAGEID = rst_TokenInfo.LANGUAGEID;
                    model_MES_SY_LANGUAGE_RETURNMX.MSGMXTEXT = model_MES_SY_LANGUAGE_RETURN.MSGNAME;
                    model_MES_SY_LANGUAGE_RETURNMX.CJRID = rst_TokenInfo.STAFFID;
                    rst = data_ISY_LANGUAGE_RETURN.RETURNMX_INSERT(model_MES_SY_LANGUAGE_RETURNMX);
                    if (rst.TYPE != "S")
                    {
                        return rst;
                    }
                    rst.TYPE = model.TYPE;
                    rst.MESSAGE = model_MES_SY_LANGUAGE_RETURN.MSGNAME;
                }
                return rst;
            }
            else
            {
                return model;
            }
        }
    }
}
