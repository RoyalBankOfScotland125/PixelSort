using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelSort {
	class Program {
		static void Main(string[] args) {
			Bitmap original = new Bitmap("testimage.png");
			sortPixel(original);
		}

		private static void sortPixel(Bitmap input) {
			
			for(int x = 0; x < input.Width - 1; x++) {

				int[] startEndPoint = getSortRange(input, x);

				for(int y = 0; y < input.Height - 1; y++) {
					
					
					

				}
			}
		}

		private static int[] getSortRange(Bitmap input, int col) {
			int[] startEnd = new int[2];
			for(int i = 0; i < input.Height; i++) {
				int B = (int) input.GetPixel(col, i).GetBrightness();
			}
		}
	}
}

