using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Product
    {
        public enum ProductType
        {
            COURSE = 1,
            BOOK,
            CD,
            OTHER,
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; }

        //public int Id
        //{
        //    get
        //    {
        //        return this.id;
        //    }

        //    set
        //    {
        //        this.id = value;
        //    }
        //}

        //public string Type
        //{
        //    get
        //    {
        //        return this.type;
        //    }

        //    set
        //    {
        //        this.type = value;
        //    }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        return this.name;
        //    }

        //    set
        //    {
        //        this.name = value;
        //    }
        //}

        //public double Price
        //{
        //    get
        //    {
        //        return this.price;
        //    }

        //    set
        //    {
        //        this.price = value;
        //    }
        //}        
    }
}
