using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterAPI
{
    public class Rate
    {
        public double AED { get; set; }//United Arab Emirates Dirham
        public double AFN { get; set; }//Afghan Afghani
        public double ALL { get; set; }//Albanian Lek
        public double AMD { get; set; }//Armenian Dram
        public double ANG { get; set; }//Netherlands Antillean Guilder
        public double AOA { get; set; }//Angolan Kwanza
        public double ARS { get; set; }//Argentine Peso
        public double AUD { get; set; }//Australian Dollar
        public double AWG { get; set; }//Aruban Florin
        public double AZN { get; set; }//Azerbaijani Manat
        public double BAM { get; set; }//Bosnia-Herzegovina Convertible Mark
        public double BBD { get; set; }//Barbadian Dollar
        public double BDT { get; set; }//Bangladeshi Taka
        public double BGN { get; set; }//Bulgarian Lev
        public double BHD { get; set; }//Bahraini Dinar
        public double BIF { get; set; }//Burundian Franc
        public double BMD { get; set; }//Bermudan Dollar
        public double BND { get; set; }//Brunei Dollar
        public double BOB { get; set; }//Bolivian Boliviano
        public double BRL { get; set; }//Brazilian Real
        public double BSD { get; set; }//Bahamian Dollar
        public double BTC { get; set; }//Bitcoin
        public double BTN { get; set; }//Bhutanese Ngultrum
        public double BWP { get; set; }//Botswanan Pula
        public double BYN { get; set; }//Belarusian Ruble
        public double BYR { get; set; }//Belarusian Ruble(pre-2016)
        public double BZD { get; set; }//Belize Dollar
        public double CAD { get; set; }//Canadian Dollar
        public double CDF { get; set; }//Congolese Franc
        public double CHF { get; set; }//Swiss Franc
        public double CLF { get; set; }//Chilean Unit of Account(UF)
        public double CLP { get; set; }//Chilean Peso
        public double CNH { get; set; }//Chinese Yuan(Offshore)
        public double CNY { get; set; }//Chinese Yuan
        public double COP { get; set; }//Colombian Peso
        public double CRC { get; set; }//Costa Rican Colón
        public double CUC { get; set; }//Cuban Convertible Peso
        public double CUP { get; set; }//Cuban Peso
        public double CVE { get; set; }//Cape Verdean Escudo
        public double CZK { get; set; }//Czech Republic Koruna
        public double DJF { get; set; }//Djiboutian Franc
        public double DKK { get; set; }//Danish Krone
        public double DOP { get; set; }//Dominican Peso
        public double DZD { get; set; }//Algerian Dinar
        public double EEK { get; set; }//Estonian Kroon
        public double EGP { get; set; }//Egyptian Pound
        public double ERN { get; set; }//Eritrean Nakfa
        public double ETB { get; set; }//Ethiopian Birr
        public double EUR { get; set; }//Euro
        public double FJD { get; set; }//Fijian Dollar
        public double FKP { get; set; } //Falkland Islands Pound
        public double GBP { get; set; } //British Pound Sterling
        public double GEL { get; set; } //Georgian Lari
        public double GGP { get; set; } //Guernsey Pound
        public double GHS { get; set; } //Ghanaian Cedi
        public double GIP { get; set; } //Gibraltar Pound
        public double GMD { get; set; } //Gambian Dalasi
        public double GNF { get; set; } //Guinean Franc
        public double GTQ { get; set; } //Guatemalan Quetzal
        public double GYD { get; set; } //Guyanaese Dollar
        public double HKD { get; set; } //Hong Kong Dollar
        public double HNL { get; set; } //Honduran Lempira
        public double HRK { get; set; } //Croatian Kuna
        public double HTG { get; set; } //Haitian Gourde
        public double HUF { get; set; } //Hungarian Forint
        public double IDR { get; set; } //Indonesian Rupiah
        public double ILS { get; set; } //Israeli New Sheqel
        public double IMP { get; set; } //Manx pound
        public double INR { get; set; } //Indian Rupee
        public double IQD { get; set; } //Iraqi Dinar
        public double IRR { get; set; } //Iranian Rial
        public double ISK { get; set; } //Icelandic Króna
        public double JEP { get; set; } //Jersey Pound
        public double JMD { get; set; } //Jamaican Dollar
        public double JOD { get; set; } //Jordanian Dinar
        public double JPY { get; set; } //Japanese Yen
        public double KES { get; set; } //Kenyan Shilling
        public double KGS { get; set; } //Kyrgystani Som
        public double KHR { get; set; } //Cambodian Riel
        public double KMF { get; set; } //Comorian Franc
        public double KPW { get; set; } //North Korean Won
        public double KRW { get; set; } //South Korean Won
        public double KWD { get; set; } //Kuwaiti Dinar
        public double KYD { get; set; } //Cayman Islands Dollar
        public double KZT { get; set; } //Kazakhstani Tenge
        public double LAK { get; set; } //Laotian Kip
        public double LBP { get; set; } //Lebanese Pound
        public double LKR { get; set; } //Sri Lankan Rupee
        public double LRD { get; set; } //Liberian Dollar
        public double LSL { get; set; } //Lesotho Loti
        public double LYD { get; set; } //Libyan Dinar
        public double MAD { get; set; } //Moroccan Dirham
        public double MDL { get; set; } //Moldovan Leu
        public double MGA { get; set; } //Malagasy Ariary
        public double MKD { get; set; } //Macedonian Denar
        public double MMK { get; set; } //Myanma Kyat
        public double MNT { get; set; } //Mongolian Tugrik
        public double MOP { get; set; } //Macanese Pataca
        public double MRO { get; set; } //Mauritanian Ouguiya(pre-2018)
        public double MRU { get; set; } //Mauritanian Ouguiya
        public double MTL { get; set; } //Maltese Lira
        public double MUR { get; set; } //Mauritian Rupee
        public double MVR { get; set; } //Maldivian Rufiyaa
        public double MWK { get; set; } //Malawian Kwacha
        public double MXN { get; set; } //Mexican Peso
        public double MYR { get; set; } //Malaysian Ringgit
        public double MZN { get; set; } //Mozambican Metical
        public double NAD { get; set; } //Namibian Dollar
        public double NGN { get; set; } //Nigerian Naira
        public double NIO { get; set; } //Nicaraguan Córdoba
        public double NOK { get; set; } //Norwegian Krone
        public double NPR { get; set; } //Nepalese Rupee
        public double NZD { get; set; } //New Zealand Dollar
        public double OMR { get; set; } //Omani Rial
        public double PAB { get; set; } //Panamanian Balboa
        public double PEN { get; set; } //Peruvian Nuevo Sol
        public double PGK { get; set; } //Papua New Guinean Kina
        public double PHP { get; set; } //Philippine Peso
        public double PKR { get; set; } //Pakistani Rupee
        public double PLN { get; set; } //Polish Zloty
        public double PYG { get; set; } //Paraguayan Guarani
        public double QAR { get; set; } //Qatari Rial
        public double RON { get; set; } //Romanian Leu
        public double RSD { get; set; } //Serbian Dinar
        public double RUB { get; set; } //Russian Ruble
        public double RWF { get; set; } //Rwandan Franc
        public double SAR { get; set; } //Saudi Riyal
        public double SBD { get; set; } //Solomon Islands Dollar
        public double SCR { get; set; } //Seychellois Rupee
        public double SDG { get; set; } //Sudanese Pound
        public double SEK { get; set; } //Swedish Krona
        public double SGD { get; set; } //Singapore Dollar
        public double SHP { get; set; } //Saint Helena Pound
        public double SLL { get; set; } //Sierra Leonean Leone
        public double SOS { get; set; } //Somali Shilling
        public double SRD { get; set; } //Surinamese Dollar
        public double SSP { get; set; } //South Sudanese Pound
        public double STD { get; set; } //São Tomé and Príncipe Dobra(pre-2018)
        public double STN { get; set; } //São Tomé and Príncipe Dobra
        public double SVC { get; set; } //Salvadoran Colón
        public double SYP { get; set; } //Syrian Pound
        public double SZL { get; set; } //Swazi Lilangeni
        public double THB { get; set; } //Tunisian Dinar
        public double TOP { get; set; } //Tongan Paʻanga
        public double TRY { get; set; } //Turkish Lira
        public double TTD { get; set; } //Trinidad and Tobago Dollar
        public double TWD { get; set; } //New Taiwan Dollar
        public double TZS { get; set; } //Tanzanian Shilling
        public double UAH { get; set; } //Ukrainian Hryvnia
        public double UGX { get; set; } //Ugandan Shilling
        public double USD { get; set; } //United States Dollar
        public double UYU { get; set; } //Uruguayan Peso
        public double UZS { get; set; } //Uzbekistan Som
        public double VES { get; set; } //Venezuelan Bolívar Soberano
        public double VND { get; set; } //Vietnamese Dong
        public double VUV { get; set; } //Vanuatu Vatu
        public double WST { get; set; } //Samoan Tala
        public double XAF { get; set; } //CFA Franc BEAC
        public double XAG { get; set; } //Silver(troy ounce)
        public double XAU { get; set; } //Gold(troy ounce)
        public double XCD { get; set; } //East Caribbean Dollar
        public double XDR { get; set; } //Special Drawing Rights
        public double XOF { get; set; } //CFA Franc BCEAO
        public double XPD { get; set; } //Palladium Ounce
        public double XPF { get; set; } //CFP Franc
        public double XPT { get; set; } //Platinum Ounce
        public double YER { get; set; } //Yemeni Rial
        public double ZAR { get; set; } //South African Rand
        public double ZMK { get; set; } //Zambian Kwacha(pre-2013)
        public double ZMW { get; set; } //Zambian Kwacha
    }
}
