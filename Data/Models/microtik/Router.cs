using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models.microtik
{
    public class Router
    {
        public string? id {get;set;}
        public string? nombre{get;set;}
        public string? ip{get;set;}
        public string?coordenadas {get;set;}
        public string? version {get;set;}
        public string? estado{get;set;}
        public string?modelo{get;set;}
        public string? serial{get;set;}
    }
}