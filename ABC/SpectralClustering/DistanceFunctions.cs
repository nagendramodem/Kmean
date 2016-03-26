﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace SpectralClustering
{
    public static class DistanceFunctions
    {
        public static double RBFKernelVectors(Vector<double> p1, Vector<double> p2)
        {
            var euc = Distance.Euclidean(p1, p2);
            return Math.Exp(-(Math.Pow(euc, 2)) / (2 * Math.Pow(0.5, 2)));
        }
        public static double RBFKernel(Point p1, Point p2)
        {
            var euc = p1.dist(p2);
            return Math.Exp(-(Math.Pow(euc, 2)) / (2 * Math.Pow(0.5, 2)));
        }
        public static double RBFKernel2(Point p1, Point p2)
        {
            return Math.Exp(-(Math.Pow(p1.manhattan_dist(p2), 2)) / (2 * Math.Pow(0.5, 2)));
        }
        public static double SquaredEuclideanDistance(Point p1, Point p2)
        {
            return -Math.Pow(Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2)), 2);
        }
        public static double EuclideanDistance(Point p1, Point p2)
        {
            return -p1.dist(p2);
        }
        public static double CosineSimilarity(Point p1, Point p2)
        {
            double[] p1a = { p1.x, p1.y };
            double[] p2a = { p2.x, p2.y };
            var res = Distance.Cosine(p1a, p2a);
            res = double.IsNaN(res) ? 0f : res;
            return Math.Exp(-(Math.Pow(res, 2)) / (2 * Math.Pow(0.5, 2)));
        }
    }
}
