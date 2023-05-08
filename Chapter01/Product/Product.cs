using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    //商品クラス
    class Product {
        //自動実装プロパティ
        public int Code { get; set; }   //商品コード
        public string Name { get; set; }   //商品名
        public int Price { get; set; }  //商品価格(税抜き)


        //コンストラクタ
        public Product(int code,string name,int price) {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }


        //消費税額を決める(消費税率は10％)
        public int GetTax() {
            return (int)(Price * 0.1);
        }


        //税込価格を求める
        public int GetPriceIncludingtax() {
            return Price + GetTax();
        }
    }
}
