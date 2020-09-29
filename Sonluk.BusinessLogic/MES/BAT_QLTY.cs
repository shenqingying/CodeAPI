using Sonluk.DAFactory;
using Sonluk.Entities.MES;
using Sonluk.IDataAccess.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.BusinessLogic.MES
{
    public class BAT_QLTY
    {
        private static readonly IBAT_QLTY mesdataAccess = MESDataAccess.CreateBAT_QLTY();
        private static readonly IBAT_QLTY_STAFF DA_BAT_QLTY_STAFF = MESDataAccess.CreateBAT_QLTY_STAFF();
        private static readonly IBAT_QLTY_TMARK DA_BAT_QLTY_TMARK = MESDataAccess.CreateBAT_QLTY_TMARK();
        private static readonly ISY_SYSCS DA_SY_SYSCS = MESDataAccess.CreateISY_SYSCS();

        public MES_ZLRBB_SELECT SELECT(MES_ZLRBB_SEARCH model)
        {
            return mesdataAccess.SELECT(model);
        }

        public MES_ZLRBB_SELECT SELECT_SUM(MES_ZLRBB_SEARCH model)
        {
            MES_ZLRBB_SELECT rst = new MES_ZLRBB_SELECT();
            rst.MES_ZLRBB = new List<MES_ZLRBB>();
            MES_ZLRBB_SELECT rst_MES_ZLRBB_SELECT = mesdataAccess.SELECT_SUM(model);
            rst.MES_RETURN = rst_MES_ZLRBB_SELECT.MES_RETURN;
            if (rst_MES_ZLRBB_SELECT.MES_RETURN.TYPE == "S")
            {
                if (rst_MES_ZLRBB_SELECT.MES_ZLRBB.Count > 0)
                {
                    if (model.SDLINE == "")
                    {
                        string[] PLine = DA_SY_SYSCS.SELECT("MES_BAT_QLTY_PL").Split(',');
                        for (int i = 0; i < PLine.Length; i++)
                        {
                            MES_ZLRBB child = new MES_ZLRBB();
                            child.SDLINE = PLine[i];
                            for (int j = 0; j < rst_MES_ZLRBB_SELECT.MES_ZLRBB.Count; j++)
                            {
                                if (rst_MES_ZLRBB_SELECT.MES_ZLRBB[j].SDLINE == PLine[i])
                                {
                                    child = rst_MES_ZLRBB_SELECT.MES_ZLRBB[j];
                                    break;
                                }
                            }
                            rst.MES_ZLRBB.Add(child);
                        }
                    }
                    else
                    {

                        for (int i = 0; i < 64; i++)
                        {
                            MES_ZLRBB child = new MES_ZLRBB();
                            child.JLTXR = "";
                            child.BZ = "";
                            rst.MES_ZLRBB.Add(child);
                        }
                        int listnum = rst_MES_ZLRBB_SELECT.MES_ZLRBB.Count - 1;
                        if (rst_MES_ZLRBB_SELECT.MES_ZLRBB[rst_MES_ZLRBB_SELECT.MES_ZLRBB.Count - 1].LB == 5)
                        {
                            listnum = rst_MES_ZLRBB_SELECT.MES_ZLRBB.Count - 2;
                            rst.MES_ZLRBB[63] = rst_MES_ZLRBB_SELECT.MES_ZLRBB[listnum + 1];
                        }
                        rst.MES_ZLRBB[62] = rst_MES_ZLRBB_SELECT.MES_ZLRBB[listnum];
                        for (int i = 0; i < listnum; i++)
                        {
                            int day = Convert.ToInt32(rst_MES_ZLRBB_SELECT.MES_ZLRBB[i].DATE);
                            string bc = rst_MES_ZLRBB_SELECT.MES_ZLRBB[i].BC;
                            if (bc == "日")
                            {
                                rst.MES_ZLRBB[day * 2 - 2] = rst_MES_ZLRBB_SELECT.MES_ZLRBB[i];
                            }
                            else if (bc == "中")
                            {
                                rst.MES_ZLRBB[day * 2 - 1] = rst_MES_ZLRBB_SELECT.MES_ZLRBB[i];
                            }
                            else
                            {
                                rst.MES_ZLRBB[day * 2 - 2].VYS = rst_MES_ZLRBB_SELECT.MES_ZLRBB[i].VYS;
                                rst.MES_ZLRBB[day * 2 - 2].VZ = rst_MES_ZLRBB_SELECT.MES_ZLRBB[i].VZ;
                                rst.MES_ZLRBB[day * 2 - 2].VYX = rst_MES_ZLRBB_SELECT.MES_ZLRBB[i].VYX;
                                rst.MES_ZLRBB[day * 2 - 2].SDZYXCCD = rst_MES_ZLRBB_SELECT.MES_ZLRBB[i].SDZYXCCD;
                                rst.MES_ZLRBB[day * 2 - 2].WGBL = rst_MES_ZLRBB_SELECT.MES_ZLRBB[i].WGBL;
                            }
                        }
                    }
                }
                else
                {
                    rst.MES_RETURN.TYPE = "E";
                    rst.MES_RETURN.MESSAGE = "该月无数据！";
                }
            }
            else rst = rst_MES_ZLRBB_SELECT;
            return rst;
        }

        public MES_ZLRBB_SELECT TMARK_SELECT_SUM(MES_ZLRBB_SEARCH model)
        {
            MES_ZLRBB_SELECT rst = new MES_ZLRBB_SELECT();
            rst.MES_ZLRBB = new List<MES_ZLRBB>();
            rst.MES_RETURN = new MES_RETURN();
            MES_ZLRBB_SELECT rst_TMARK = DA_BAT_QLTY_TMARK.SELECT_SUM(model);
            if (rst_TMARK.MES_RETURN.TYPE == "S")
            {
                if (rst_TMARK.MES_ZLRBB.Count > 0)
                {
                    if (model.SDLINE == "")
                    {
                        string[] PLine = DA_SY_SYSCS.SELECT("MES_BAT_QLTY_PL").Split(',');
                        for (int i = 0; i < PLine.Length; i++)
                        {
                            MES_ZLRBB child = new MES_ZLRBB();
                            child.SDLINE = PLine[i];
                            for (int j = 0; j < rst_TMARK.MES_ZLRBB.Count; j++)
                            {
                                if (rst_TMARK.MES_ZLRBB[j].SDLINE == PLine[i])
                                {
                                    child = rst_TMARK.MES_ZLRBB[j];
                                    break;
                                }
                            }
                            rst.MES_ZLRBB.Add(child);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            MES_ZLRBB child = new MES_ZLRBB();
                            rst.MES_ZLRBB.Add(child);
                        }
                        rst.MES_ZLRBB[0] = rst_TMARK.MES_ZLRBB[0];
                        for (int i = 1; i < rst_TMARK.MES_ZLRBB.Count; i++)
                        {
                            int day = Convert.ToInt32(rst_TMARK.MES_ZLRBB[i].DATE);
                            rst.MES_ZLRBB[day] = rst_TMARK.MES_ZLRBB[i];
                        }
                    }
                    rst.MES_RETURN = rst_TMARK.MES_RETURN;
                }
                else
                {
                    rst.MES_RETURN.TYPE = "E";
                    rst.MES_RETURN.MESSAGE = "该月无数据！";
                }
            }
            else
            {
                rst = rst_TMARK;
            }
            return rst;
        }

        public MES_RETURN COVER(MES_ZLRBB model, int STAFFID)
        {
            model.CJRID = STAFFID;
            MES_RETURN rst = mesdataAccess.COVER(model);
            if ((model.VYX > 0 || model.ID > 0) && rst.TYPE == "S")
            {
                if (model.RI <= 0) model.RI = rst.TID;
                rst = DA_BAT_QLTY_TMARK.COVER(model);
            }
            return rst;
        }

        public MES_RETURN COVER_TMARK(MES_ZLRBB model, int STAFFID)
        {
            model.CJRID = STAFFID;
            MES_RETURN rst = mesdataAccess.COVER_TMARK(model);
            if ((model.VYX > 0 || model.ID > 0) && rst.TYPE == "S")
            {
                if (model.RI <= 0) model.RI = rst.TID;
                rst = DA_BAT_QLTY_TMARK.COVER(model);
            }
            return rst;
        }

        public MES_RETURN ACTION(int RI)
        {
            return mesdataAccess.ACTION(RI);
        }

        public MES_RETURN DELETE(int RI, int STAFFID)
        {
            return mesdataAccess.DELETE(RI, STAFFID);
        }

        public MES_RETURN DELETE_TMARK(int RI)
        {
            return mesdataAccess.DELETE_TMARK(RI);
        }

        public MES_SELECT<MES_ZLRBB_STAFF> STAFF_SELECT(MES_ZLRBB_STAFF model)
        {
            return DA_BAT_QLTY_STAFF.SELECT(model);
        }
    }
}
