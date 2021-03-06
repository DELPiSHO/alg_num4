﻿using System;
using System.Collections.Generic;
using System.Text;

namespace csi
{
	class Jacobi
	{
		private Matrix Matrix { get; set; }
		private Matrix Vector { get; set; }

		public Jacobi(Matrix matrix, Matrix vector)
		{
			Matrix = DeepCopy.Copy(matrix);
			Vector = DeepCopy.Copy(vector);
		}

		public Matrix Calculate()
		{
			Matrix last = new Matrix(Vector.rows, 1);
			Matrix current = new Matrix(Vector.rows, 1);

			double value;
            int iterations = 0;


			do
			{
                iterations++;
				for (int i = 0; i < Matrix.rows; i++)
				{
					double sum = 0;
					sum += Vector.values[i, 0];

					for (int j = 0; j < Matrix.cols; j++)
					{
						if (i != j)
						{
							sum -= Matrix.values[i, j] * last.values[j, 0];
						}
					}

					current.values[i, 0] = sum / Matrix.values[i, i];
				}
                value = (current - last).GetNorm();
                last = DeepCopy.Copy(current);
			}
			while (value > 0.001);

			return current;
		}
	}
}
