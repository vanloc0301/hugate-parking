using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;

namespace Hugate.DataHelper
{
    public class Execute
    {
        string pathFrontImage = @"D:\ImageParking\Front\";
        string pathBackImage = @"D:\ImageParking\Back\";
        Bitmap pubBitmap;

        PKDataContext _dataContext;
        public Execute(PKDataContext dataContext)
        {
            _dataContext = dataContext;
            if (_dataContext.Connection.State == ConnectionState.Closed)
            {
                _dataContext.Connection.Open();
            }
        }

        public pk_In_Out[] GetAll()
        {
            return _dataContext.pk_In_Outs.ToArray();
        }

        public pk_In_Out[] GetAll(DateTime fromDateTime, DateTime toDateTime)
        {
            var result = from pk in _dataContext.pk_In_Outs
                         where pk.TimeIn >= fromDateTime && pk.TimeIn <= toDateTime
                         select pk;
            return result.ToArray();
        }

        public pk_In_Out[] GetAllPKIn()
        {
            var result = from pkIn in _dataContext.pk_In_Outs
                         where pkIn.IsOut == false
                         orderby pkIn.TimeIn descending
                         select pkIn;
            return result.ToArray();
        }

        public pk_In_Out[] GetAllPKIn(int skip, int take)
        {
            var result = from pkIn in _dataContext.pk_In_Outs
                         where pkIn.IsOut == false
                         orderby pkIn.TimeIn descending
                         select pkIn;
            if (take >= 0) return result.Skip(skip).Take(take).ToArray();
            return result.Skip(skip).ToArray();
        }

        public pk_In_Out[] GetAllPKOut(int skip, int take)
        {
            var result = from pkIn in _dataContext.pk_In_Outs
                         where pkIn.IsOut == true
                         orderby pkIn.TimeIn descending
                         select pkIn;
            if (take >= 0) return result.Skip(skip).Take(take).ToArray();
            return result.Skip(skip).ToArray();
        }

        public bool HasObject(string RFID)
        {
            return _dataContext.pk_In_Outs.Any(x => x.RFID == RFID && x.IsOut == false);
        }

        public vw_Pk_All GetSinglePKIn(string RFID)
        {
            var result = from pkIn in _dataContext.vw_Pk_Alls
                         where pkIn.RFID == RFID && pkIn.IsOut == false
                         orderby pkIn.TimeIn descending
                         select pkIn;
            return result.FirstOrDefault();
        }

        public pk_In_Out GetSinglePKOut(string RFID)
        {
            var result = from pkIn in _dataContext.pk_In_Outs
                         where pkIn.RFID == RFID && pkIn.IsOut == true
                         orderby pkIn.TimeOut descending
                         select pkIn;
            return result.FirstOrDefault();
        }

        public Guid SavePKIn(pk_In_Out _Object)
        {
            _dataContext.pk_In_Outs.InsertOnSubmit(_Object);
            _dataContext.SubmitChanges();
            return _Object.ID;
        }

        public Guid SavePKIn(string RFID, string Number, DateTime TimeIn, int VehicleTypeID)
        {
            pk_In_Out PKIn = new pk_In_Out();
            PKIn.ID = System.Guid.NewGuid();
            PKIn.RFID = RFID;
            PKIn.Number = Number;
            PKIn.TimeIn = TimeIn;
            PKIn.VehicleTypeID = VehicleTypeID;
            return SavePKIn(PKIn);
        }

        public void SavePKOut(Guid ID, pk_In_Out _Object)
        {
            pk_In_Out _obj = _dataContext.pk_In_Outs.FirstOrDefault(x => x.ID == ID);
            if (_obj != null)
            {
                _obj.IsOut = true;
                _obj.TimeOut = _Object.TimeOut;
            }
            _dataContext.SubmitChanges();
        }

        public void SavePKOut(Guid ID, DateTime TimeOut)
        {
            pk_In_Out PKIn = new pk_In_Out();
            PKIn.TimeOut = TimeOut;
            SavePKOut(ID, PKIn);
        }

        public void SaveCamera(pk_Camera pk_Camera)
        {
            _dataContext.pk_Cameras.InsertOnSubmit(pk_Camera);
            _dataContext.SubmitChanges();
        }

        public void SaveCamera(string name, string provider, string desc, string source, string login, string password, string size, string type, string quality, string interval, bool isIn, bool position, int areadId)
        {
            pk_Camera cam = new pk_Camera();
            cam.Name = name;
            cam.provider = provider;
            cam.desc = desc;
            cam.source = source;
            cam.login = login;
            cam.password = password;
            cam.size = size;
            cam.type = type;
            cam.quality = quality;
            cam.interval = interval;
            cam.isIn = isIn;
            cam.position = position;
            cam.areaId = areadId;
            SaveCamera(cam);
        }

        public pk_Camera[] GetAllCameras()
        {
            return _dataContext.pk_Cameras.ToArray();
        }

        public void EditCamera(int cameraId, string name, string provider, string desc, string source, string login, string password, string size, string type, string quality, string interval, bool isIn, bool position, int areadId)
        {
            pk_Camera cam = _dataContext.pk_Cameras.FirstOrDefault(x => x.CameraId == cameraId);
            if (cam != null)
            {
                cam.Name = name;
                cam.provider = provider;
                cam.desc = desc;
                cam.source = source;
                cam.login = login;
                cam.password = password;
                cam.size = size;
                cam.type = type;
                cam.quality = quality;
                cam.interval = interval;
                cam.isIn = isIn;
                cam.position = position;
                cam.areaId = areadId;
                _dataContext.SubmitChanges();
            }
        }

        public void DeleteCamera(int cameraId)
        {
            pk_Camera cam = _dataContext.pk_Cameras.FirstOrDefault(x => x.CameraId == cameraId);
            if (cam != null)
            {
                _dataContext.pk_Cameras.DeleteOnSubmit(cam);
                _dataContext.SubmitChanges();
            }

        }

        public IEnumerable<pk_Camera> IECamera()
        {
            return _dataContext.pk_Cameras.AsEnumerable();
        }

        public decimal GetPriceByID(int ID)
        {
            pk_Price cam = _dataContext.pk_Prices.FirstOrDefault(x => x.ID == ID);
            return cam.Price ?? 0;
        }

        public IEnumerable<pk_Price> IEPrice()
        {
            return _dataContext.pk_Prices.AsEnumerable();
        }

        public pk_Price[] GetAllPrice()
        {
            return _dataContext.pk_Prices.ToArray();
        }

        public void SavePrice(pk_Price price)
        {
            _dataContext.pk_Prices.InsertOnSubmit(price);
            _dataContext.SubmitChanges();
        }

        public void SavePrice(string type, decimal price, string note)
        {
            pk_Price _object = new pk_Price();
            _object.VehicleType = type;
            _object.Price = price;
            _object.Note = note;
            SavePrice(_object);
        }

        public void EditPrice(int ID, string type, decimal price, string note)
        {
            pk_Price _object = _dataContext.pk_Prices.FirstOrDefault(x => x.ID == ID);
            _object.VehicleType = type;
            _object.Price = price;
            _object.Note = note;
            _dataContext.SubmitChanges();
        }

        public void DeletePrice(int ID)
        {
            pk_Price _object = _dataContext.pk_Prices.FirstOrDefault(x => x.ID == ID);
            if (_object != null)
            {
                _dataContext.pk_Prices.DeleteOnSubmit(_object);
                _dataContext.SubmitChanges();
            }
        }

        public void DeleteCard(string RFIDCard)
        {

            pk_In_Out _obj = _dataContext.pk_In_Outs.FirstOrDefault(x => x.RFID == RFIDCard);
            if (_obj != null)
            {
                _dataContext.pk_In_Outs.DeleteOnSubmit(_obj);
            }
            _dataContext.SubmitChanges();
        }

        public IEnumerable<pk_In_Out> Search(string RFID, string Number, DateTime fromDate, DateTime toDate, bool isOut, bool isRFID, bool isNumber, bool isDate)
        {
            IEnumerable<pk_In_Out> result = null;
            if (isOut == false)
            {
                if (isRFID == true && isNumber == false && isDate == false)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.RFID == RFID && search.IsOut == false
                             select search;
                }
                else if (isRFID == false && isNumber == true && isDate == false)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.Number == Number && search.IsOut == false
                             select search;
                }
                else if (isRFID == false && isNumber == false && isDate == true)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.TimeIn >= fromDate.AddMinutes(-1) && search.TimeIn <= toDate.AddMinutes(-1) && search.IsOut == false
                             select search;
                }
                else if (isRFID == true && isNumber == true && isDate == false)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.RFID == RFID && search.Number == Number && search.IsOut == false
                             select search;
                }
                else if (isRFID == true && isNumber == false && isDate == true)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.RFID == RFID && search.TimeIn >= fromDate.AddMinutes(-1) && search.TimeIn <= toDate.AddMinutes(-1) && search.IsOut == false
                             select search;
                }
                else if (isRFID == false && isNumber == true && isDate == true)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.Number == Number && search.TimeIn >= fromDate.AddMinutes(-1) && search.TimeIn <= toDate.AddMinutes(-1) && search.IsOut == false
                             select search;
                }
            }
            else
            {
                if (isRFID == true && isNumber == false && isDate == false)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.RFID == RFID && search.IsOut == true
                             select search;
                }
                else if (isRFID == false && isNumber == true && isDate == false)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.Number == Number && search.IsOut == true
                             select search;
                }
                else if (isRFID == false && isNumber == false && isDate == true)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.TimeOut >= fromDate.AddMinutes(-1) && search.TimeOut <= toDate.AddMinutes(-1) && search.IsOut == true
                             select search;
                }
                else if (isRFID == true && isNumber == true && isDate == false)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.RFID == RFID && search.Number == Number && search.IsOut == true
                             select search;
                }
                else if (isRFID == true && isNumber == false && isDate == true)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.RFID == RFID && search.TimeOut >= fromDate.AddMinutes(-1) && search.TimeOut <= toDate.AddMinutes(-1) && search.IsOut == true
                             select search;
                }
                else if (isRFID == false && isNumber == true && isDate == true)
                {
                    result = from search in _dataContext.pk_In_Outs
                             where search.Number == Number && search.TimeOut >= fromDate.AddMinutes(-1) && search.TimeOut <= toDate.AddMinutes(-1) && search.IsOut == true
                             select search;
                }
            }
            return result;
        }

        public void getImage(Guid ID, ref byte[] arrImg, bool position)
        {
            if (position)
            {
                if (!Directory.Exists(pathFrontImage))
                    Directory.CreateDirectory(pathFrontImage);
                string pathImg = String.Format("{0}front-{1}.jpeg", pathFrontImage, ID);
                if (!File.Exists(pathImg)) return;
                pubBitmap = new Bitmap(pathImg);
                arrImg = BitmapDataFromBitmap(pubBitmap, ImageFormat.Jpeg);
                pubBitmap.Dispose();
            }
            else
            {
                if (!Directory.Exists(pathBackImage))
                    Directory.CreateDirectory(pathBackImage);
                string pathImg = String.Format("{0}back-{1}.jpeg", pathBackImage, ID);
                if (!File.Exists(pathImg)) return;
                pubBitmap = new Bitmap(pathImg);
                arrImg = BitmapDataFromBitmap(pubBitmap, ImageFormat.Jpeg);
                pubBitmap.Dispose();
            }
        }

        public void setImage(Guid ID, byte[] arrImg, bool position)
        {
            if (position)
            {
                if (!Directory.Exists(pathFrontImage))
                    Directory.CreateDirectory(pathFrontImage);
                string pathImg = String.Format("{0}front-{1}.jpeg", pathFrontImage, ID);
                if (File.Exists(pathImg)) File.Delete(pathImg);
                pubBitmap = BitmapFromBitmapData(arrImg);
                pubBitmap.Save(pathImg, ImageFormat.Jpeg);
            }
            else
            {
                if (!Directory.Exists(pathBackImage))
                    Directory.CreateDirectory(pathBackImage);
                string pathImg = String.Format("{0}back-{1}.jpeg", pathBackImage, ID);
                if (File.Exists(pathImg)) File.Delete(pathImg);
                pubBitmap = BitmapFromBitmapData(arrImg);
                pubBitmap.Save(pathImg, ImageFormat.Jpeg);
            }
        }

        private byte[] BitmapDataFromBitmap(Bitmap objBitmap, ImageFormat imageFormat)
        {
            MemoryStream ms = new MemoryStream();
            objBitmap.Save(ms, imageFormat);
            return (ms.ToArray());
        }

        private Bitmap BitmapFromBitmapData(byte[] BitmapData)
        {
            MemoryStream ms = new MemoryStream(BitmapData);
            return (new Bitmap(ms));
        }

        public List<vw_Pk_All> TotalAmount(DateTime fromDate, DateTime toDate)
        {
            st_PK_TotalAmountResult[] result = _dataContext.st_PK_TotalAmount(fromDate, toDate).ToArray();
            List<vw_Pk_All> view = new List<vw_Pk_All>();
            if (result.Length > 0)
            {
                foreach (st_PK_TotalAmountResult item in result)
                {
                    vw_Pk_All item_ = new vw_Pk_All();
                    item_.VehicleType = item.VehicleType;
                    item_.Quantity = item.Quantity;
                    item_.Price = item.Price;
                    item_.TotalPrice = item.TotalPrice;
                    view.Add(item_);
                }
            }
            return view;
        }
    }
}
