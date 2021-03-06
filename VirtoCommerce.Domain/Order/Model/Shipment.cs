﻿using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Shipping.Model;

namespace VirtoCommerce.Domain.Order.Model
{
	public class Shipment : OrderOperation, IHaveTaxDetalization, ISupportCancellation, ITaxable
	{
		public string OrganizationId { get; set; }
		public string OrganizationName { get; set; }

		public string FulfillmentCenterId { get; set; }
		public string FulfillmentCenterName { get; set; }

		public string EmployeeId { get; set; }
		public string EmployeeName { get; set; }

        /// <summary>
        /// Current shipment method code 
        /// </summary>
		public string ShipmentMethodCode { get; set; }

        /// <summary>
        /// Current shipment option code 
        /// </summary>
        public string ShipmentMethodOption { get; set; }

        /// <summary>
        ///  Shipment method contains additional shipment method information
        /// </summary>
        public ShippingMethod ShippingMethod { get; set; }

        public string CustomerOrderId { get; set; }
		public CustomerOrder CustomerOrder { get; set; }

		public ICollection<ShipmentItem> Items { get; set; } 

		public ICollection<ShipmentPackage> Packages { get; set; }

		public ICollection<PaymentIn> InPayments { get; set; }

		public string WeightUnit { get; set; }
		public decimal? Weight { get; set; }

		public string MeasureUnit { get; set; }
		public decimal? Height { get; set; }
		public decimal? Length { get; set; }
		public decimal? Width { get; set; }

        public ICollection<Discount> Discounts { get; set; }

        public Address DeliveryAddress { get; set; }

        public virtual decimal Price { get; set; }
        public virtual decimal PriceWithTax
        {
            get
            {
                return Price + Price * TaxPercentRate;
            }
        }

        public virtual decimal Total
        {
            get
            {
                return Price - DiscountAmount;
            }
        }

        public virtual decimal TotalWithTax
        {
            get
            {
                return PriceWithTax - DiscountAmountWithTax;
            }
        }

        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal DiscountAmountWithTax
        {
            get
            {
                return DiscountAmount + DiscountAmount * TaxPercentRate;
            }
        }

        #region ITaxable Members

        /// <summary>
        /// Tax category or type
        /// </summary>
        public string TaxType { get; set; }

        public decimal TaxTotal
        {
            get
            {
                return TotalWithTax - Total;
            }
        }

        public decimal TaxPercentRate { get; set; }

        #endregion



        #region ITaxDetailSupport Members

        public ICollection<TaxDetail> TaxDetails { get; set; }

		#endregion
	}
}
