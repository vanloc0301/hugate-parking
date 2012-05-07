using System;
using System.Collections.Generic;
using System.Linq;
using Hugate.DataHelper;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Hugate.Services
{
    class Execute : AbsObject
    {
        public pk_In_Out[] GetAll()
        {
            return PKData.pk_In_Outs.ToArray();
        }

        public pk_In_Out[] GetAllPKIn()
        {
            var result = from pkIn in PKData.pk_In_Outs
                         where pkIn.IsOut == false
                         orderby pkIn.TimeIn descending
                         select pkIn;
            return result.ToArray();
        }

        public pk_In_Out[] GetAllPKIn(int skip, int take)
        {
            var result = from pkIn in PKData.pk_In_Outs
                         where pkIn.IsOut == false
                         orderby pkIn.TimeIn descending
                         select pkIn;
            if (take >= 0) return result.Skip(skip).Take(take).ToArray();
            return result.Skip(skip).ToArray();
        }

        public pk_In_Out[] GetAllPKOut(int skip, int take)
        {
            var result = from pkIn in PKData.pk_In_Outs
                         where pkIn.IsOut == true
                         orderby pkIn.TimeIn descending
                         select pkIn;
            if (take >= 0) return result.Skip(skip).Take(take).ToArray();
            return result.Skip(skip).ToArray();
        }

        public bool HasObject(string RFID)
        {
            return PKData.pk_In_Outs.Any(x => x.RFID == RFID && x.IsOut == false);
        }

        public vw_Pk_All GetSinglePKIn(string RFID)
        {
            var result = from pkIn in PKData.vw_Pk_Alls
                         where pkIn.RFID == RFID && pkIn.IsOut == false
                         orderby pkIn.TimeIn descending
                         select pkIn;
            return result.FirstOrDefault();
        }

        public pk_In_Out GetSinglePKOut(string RFID)
        {
            var result = from pkIn in PKData.pk_In_Outs
                         where pkIn.RFID == RFID && pkIn.IsOut == true
                         orderby pkIn.TimeOut descending
                         select pkIn;
            return result.FirstOrDefault();
        }

        public Guid SavePKIn(pk_In_Out _Object)
        {
            PKData.pk_In_Outs.InsertOnSubmit(_Object);
            PKData.SubmitChanges();
            return _Object.ID;
        }

        public void SavePKOut(Guid ID, pk_In_Out _Object)
        {
            pk_In_Out _obj = PKData.pk_In_Outs.FirstOrDefault(x => x.ID == ID);
            if (_obj != null)
            {
                _obj.IsOut = true;
                _obj.TimeOut = _Object.TimeOut;
            }
            PKData.SubmitChanges();
        }

        public void SaveCamera(pk_Camera pk_Camera)
        {
            PKData.pk_Cameras.InsertOnSubmit(pk_Camera);
            PKData.SubmitChanges();
        }

        public pk_Camera[] GetAllCameras()
        {
            return PKData.pk_Cameras.ToArray();
        }

        public void EditCamera(int cameraId, pk_Camera camera)
        {
            pk_Camera _obj = PKData.pk_Cameras.FirstOrDefault(x => x.CameraId == cameraId);
            if (_obj != null)
            {
                _obj.Name = camera.Name;
                _obj.provider = camera.provider;
                _obj.desc = camera.desc;
                _obj.source = camera.source;
                _obj.login = camera.login;
                _obj.password = camera.password;
                _obj.size = camera.size;
                _obj.type = camera.type;
                _obj.quality = camera.quality;
                _obj.interval = camera.interval;
                _obj.isIn = camera.isIn;
                _obj.position = camera.position;
                _obj.areaId = camera.areaId;
            }
            PKData.SubmitChanges();
        }

        public void DeleteCamera(int cameraId)
        {
            pk_Camera cam = PKData.pk_Cameras.FirstOrDefault(x => x.CameraId == cameraId);
            if (cam != null)
            {
                PKData.pk_Cameras.DeleteOnSubmit(cam);
                PKData.SubmitChanges();
            }

        }

        public IEnumerable<pk_Camera> IECamera()
        {
            return PKData.pk_Cameras.AsEnumerable();
        }

        public decimal GetPriceByID(int ID)
        {
            pk_Price cam = PKData.pk_Prices.FirstOrDefault(x => x.ID == ID);
            return cam.Price ?? 0;
        }

        public IEnumerable<pk_Price> IEPrice()
        {
            return PKData.pk_Prices.AsEnumerable();
        }

        public pk_Price[] GetAllPrice()
        {
            return PKData.pk_Prices.ToArray();
        }

        public void SavePrice(pk_Price price)
        {
            PKData.pk_Prices.InsertOnSubmit(price);
            PKData.SubmitChanges();
        }

        public void EditPrice(int ID, pk_Price price)
        {
            pk_Price _object = PKData.pk_Prices.FirstOrDefault(x => x.ID == ID);
            _object.VehicleType = price.VehicleType;
            _object.Price = price.Price;
            _object.Note = price.Note;
            PKData.SubmitChanges();
        }

        public void DeletePrice(int ID)
        {
            pk_Price _object = PKData.pk_Prices.FirstOrDefault(x => x.ID == ID);
            if (_object != null)
            {
                PKData.pk_Prices.DeleteOnSubmit(_object);
                PKData.SubmitChanges();
            }
        }

        public void DeleteCard(string RFIDCard)
        {

            pk_In_Out _obj = PKData.pk_In_Outs.FirstOrDefault(x => x.RFID == RFIDCard);
            if (_obj != null)
            {
                PKData.pk_In_Outs.DeleteOnSubmit(_obj);
            }
            PKData.SubmitChanges();
        }

        public IEnumerable<pk_In_Out> Search(string RFID, string Number, DateTime fromDate, DateTime toDate, bool isOut, bool isRFID, bool isNumber, bool isDate)
        {
            IEnumerable<pk_In_Out> result = null;
            if (isOut == false)
            {
                if (isRFID == true && isNumber == false && isDate == false)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.RFID == RFID && search.IsOut == false
                             select search;
                }
                else if (isRFID == false && isNumber == true && isDate == false)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.Number == Number && search.IsOut == false
                             select search;
                }
                else if (isRFID == false && isNumber == false && isDate == true)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.TimeIn >= fromDate.AddMinutes(-1) && search.TimeIn <= toDate.AddMinutes(-1) && search.IsOut == false
                             select search;
                }
                else if (isRFID == true && isNumber == true && isDate == false)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.RFID == RFID && search.Number == Number && search.IsOut == false
                             select search;
                }
                else if (isRFID == true && isNumber == false && isDate == true)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.RFID == RFID && search.TimeIn >= fromDate.AddMinutes(-1) && search.TimeIn <= toDate.AddMinutes(-1) && search.IsOut == false
                             select search;
                }
                else if (isRFID == false && isNumber == true && isDate == true)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.Number == Number && search.TimeIn >= fromDate.AddMinutes(-1) && search.TimeIn <= toDate.AddMinutes(-1) && search.IsOut == false
                             select search;
                }
            }
            else
            {
                if (isRFID == true && isNumber == false && isDate == false)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.RFID == RFID && search.IsOut == true
                             select search;
                }
                else if (isRFID == false && isNumber == true && isDate == false)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.Number == Number && search.IsOut == true
                             select search;
                }
                else if (isRFID == false && isNumber == false && isDate == true)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.TimeOut >= fromDate.AddMinutes(-1) && search.TimeOut <= toDate.AddMinutes(-1) && search.IsOut == true
                             select search;
                }
                else if (isRFID == true && isNumber == true && isDate == false)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.RFID == RFID && search.Number == Number && search.IsOut == true
                             select search;
                }
                else if (isRFID == true && isNumber == false && isDate == true)
                {
                    result = from search in PKData.pk_In_Outs
                             where search.RFID == RFID && search.TimeOut >= fromDate.AddMinutes(-1) && search.TimeOut <= toDate.AddMinutes(-1) && search.IsOut == true
                             select search;
                }
                else if (isRFID == false && isNumber == true && isDate == true)
                {
                    result = from search in PKData.pk_In_Outs
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
            st_PK_TotalAmountResult[] result = PKData.st_PK_TotalAmount(fromDate, toDate).ToArray();
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
