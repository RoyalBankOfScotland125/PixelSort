using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelSort {
	class Program {
		static void Main(string[] args) {
			Bitmap original = new Bitmap("D:\\Documents\\GitHub\\PixelSort\\PixelSort\\testimage.png");
			sortPixel(original);
		}

		private static void sortPixel(Bitmap input) {
			
			for(int x = 0; x < input.Width - 1; x++) {

				int[] startEndPoint = getSortRange(input, x);
				Color[] pixArray = buildArray(startEndPoint, input, x);
				mergeSort(pixArray);
				writePixels(pixArray, startEndPoint, input, x);
				
			}
			input.Save("D:\\Documents\\GitHub\\PixelSort\\PixelSort\\newImage.png");
		}

		private static void writePixels(Color[] pixArray, int[] startEndPoint, Bitmap input, int x) {
			for(int y = startEndPoint[0]; y < startEndPoint[1]; y++) {
				input.SetPixel(x, y, pixArray[y - startEndPoint[0]]);
			}
		}

		private static void mergeSort(Color[] numbers) {
			if(numbers.Length > 1) {
				Color[] a = copyOfRange(numbers, 0, numbers.Length / 2);
				Color[] b = copyOfRange(numbers, numbers.Length / 2, numbers.Length);
				
				mergeSort(a);
				mergeSort(b);
				merge(numbers, a, b);
			}
		}

		private static void merge(Color[] numbers, Color[] a, Color[] b) {
			int i1 = 0;
			int i2 = 0;
			for(int i = 0; i < numbers.Length; i++) {
				if(i2 >= b.Length || (i1 < a.Length && a[i1].GetHue() <= b[i2].GetHue())) {
					numbers[i] = a[i1];
					i1++;		
				} else {
					numbers[i] = b[i2];
					i2++;
				}
			}
		}

		private static Color[] buildArray(int[] startEndPoint, Bitmap input, int col) {
			Color[] pixels = new Color[startEndPoint[1] - startEndPoint[0]];
			for(int y = startEndPoint[0]; y < startEndPoint[1]; y++) {
				pixels[y - startEndPoint[0]] = input.GetPixel(col, y);
			}
			return pixels;
		}

		private static int[] getSortRange(Bitmap input, int col) {
			int[] startEnd = new int[2];
			for(int i = 0; i < input.Height; i++) {
				Color currentPix = input.GetPixel(col, i);
				double R = currentPix.R;
				double B = currentPix.B;
				double G = currentPix.G;
				double b = Math.Sqrt(0.299 * R * R + 0.587 * G * G + 0.114 * B * B);
				if(b < .05)
					startEnd[0] = i;
			}
			for(int j = startEnd[0]; j < input.Height; j++) {
				Color currentPix = input.GetPixel(col, j);
				double R = currentPix.R;
				double B = currentPix.B;
				double G = currentPix.G;
				double b = Math.Sqrt(0.299 * R * R + 0.587 * G * G + 0.114 * B * B);
				if(b > .95)
					startEnd[1] = j;
			}
			return startEnd;
		}

		private static Color[] copyOfRange(Color[] src, int start, int end) {
			int len = end - start;
			Color[] dest = new Color[len];
			Array.Copy(src, start, dest, 0, len);
			return dest;
		}
	}
}

