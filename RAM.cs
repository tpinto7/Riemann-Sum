using System;
using static System.Console;
using static System.Math;

namespace Bme121
{
    class Program
    {
        static void Main()
        {
            WriteLine( CalculateMRAM( 0, PI, 4, Sine ) );
			double Sine( double val ){ return Sin(val); } 
        }
        
        public delegate double Function( double val );
        
        
        static double CalculateLRAM( double start, double end, double intervals, Function func )
        {
			double ram = 0;
			double delta = (end - start)/intervals;
			for( int i = 0; i < intervals; i ++ )
			{
				double xValue = start;
				xValue += delta*i;
				
				ram += delta*func( xValue );
			}
			return ram;
		}
        
        static double CalculateRRAM( double start, double end, double intervals, Function func )
        {
			double ram = 0;
			double delta = (end - start)/intervals;
			for( int i = 0; i < intervals; i ++ )
			{
				double xValue = start;
				xValue += delta*i;
				xValue += delta;
				
				ram += delta*Sin( xValue );
			}
			return ram;
		}
		
		static double CalculateMRAM( double start, double end, double intervals, Function func )
        {
			double ram = 0;
			double delta = (end - start)/intervals;
			for( int i = 0; i < intervals; i ++ )
			{
				double xValue = start;
				xValue += delta*i;
				xValue += delta/2;
				
				ram += delta*Sin( xValue );
			}
			return ram;
		}
        
        
        static double CalculateLowerRAM( double start, double end, double intervals, Function func )
        {
			double ram = 0;
			double delta = (end - start)/intervals;
			for( int i = 0; i < intervals; i ++ )
			{
				double xValue = start;
				xValue += delta*i;
				
				if( xValue >= PI/2 ) xValue += delta;
				
				ram += delta*Sin( xValue );
			}
			return ram;
		}
		
		static double CalculateUpperRAM( double start, double end, double intervals, Function func )
        {
			double ram = 0;
			double delta = (end - start)/intervals;
			for( int i = 0; i < intervals; i ++ )
			{
				double xValue = start;
				xValue += delta*i;
				
				if( xValue < PI/2 ) xValue += delta;
				
				
				ram += delta*Sin( xValue );
			}
			return ram;
		}
		
    }
}
