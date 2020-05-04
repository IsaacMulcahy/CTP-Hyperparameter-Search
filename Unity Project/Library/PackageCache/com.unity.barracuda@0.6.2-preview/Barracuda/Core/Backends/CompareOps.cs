namespace Barracuda {


public class CompareOps : IOps
{
    private readonly IOps m_Ops1;
    private readonly IOps m_Ops2;
    private readonly bool m_DifferenceAsError;

    public CompareOps(IOps ops1, IOps ops2, bool differenceAsError)
    {
        m_Ops1 = ops1;
        m_Ops2 = ops2;
        m_DifferenceAsError = differenceAsError;
    }

    public virtual void WaitForCompletion(Tensor x)
    {
        m_Ops1.WaitForCompletion(x);
        m_Ops2.WaitForCompletion(x);
    }

    Tensor IOps.MatMul(Tensor X, bool xTranspose, Tensor W, bool wTranspose)
    {
        var Y = m_Ops1.MatMul(X, xTranspose, W, wTranspose);
        var Z = m_Ops2.MatMul(X, xTranspose, W, wTranspose);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.MatMul);
        return Y;
    }
    Tensor IOps.Dense(Tensor X, Tensor W, Tensor B)
    {
        var Y = m_Ops1.Dense(X, W, B);
        var Z = m_Ops2.Dense(X, W, B);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Dense);
        return Y;
    }

    Tensor IOps.Conv2D(Tensor X, Tensor K, Tensor B, int[] stride, int[] pad)
    {
        var Y = m_Ops1.Conv2D(X, K, B, stride, pad);
        var Z = m_Ops2.Conv2D(X, K, B, stride, pad);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Conv2D);
        return Y;
    }
    Tensor IOps.DepthwiseConv2D(Tensor X, Tensor K, Tensor B, int[] stride, int[] pad)
    {
        var Y = m_Ops1.DepthwiseConv2D(X, K, B, stride, pad);
        var Z = m_Ops2.DepthwiseConv2D(X, K, B, stride, pad);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.DepthwiseConv2D);
        return Y;
    }
    Tensor IOps.Conv2DTrans(Tensor X, Tensor K, Tensor B, int[] stride, int[] pad, int[] outputAdjustment)
    {
        var Y = m_Ops1.Conv2DTrans(X, K, B, stride, pad, outputAdjustment);
        var Z = m_Ops2.Conv2DTrans(X, K, B, stride, pad, outputAdjustment);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Conv2DTrans);
        return Y;
    }
    Tensor IOps.Upsample2D(Tensor X, int[] size)
    {
        var Y = m_Ops1.Upsample2D(X, size);
        var Z = m_Ops2.Upsample2D(X, size);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Upsample2D);
        return Y;
    }
    Tensor IOps.MaxPool2D(Tensor X, int[] pool, int[] stride, int[] pad)
    {
        var Y = m_Ops1.MaxPool2D(X, pool, stride, pad);
        var Z = m_Ops2.MaxPool2D(X, pool, stride, pad);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.MaxPool2D);
        return Y;
    }
    Tensor IOps.AvgPool2D(Tensor X, int[] pool, int[] stride, int[] pad)
    {
        var Y = m_Ops1.AvgPool2D(X, pool, stride, pad);
        var Z = m_Ops2.AvgPool2D(X, pool, stride, pad);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.AvgPool2D);
        return Y;
    }
    Tensor IOps.GlobalMaxPool2D(Tensor X)
    {
        var Y = m_Ops1.GlobalMaxPool2D(X);
        var Z = m_Ops2.GlobalMaxPool2D(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.GlobalMaxPool2D);
        return Y;
    }
    Tensor IOps.GlobalAvgPool2D(Tensor X)
    {
        var Y = m_Ops1.GlobalAvgPool2D(X);
        var Z = m_Ops2.GlobalAvgPool2D(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.GlobalAvgPool2D);
        return Y;
    }
    Tensor IOps.GlobalAvgVariancePool2D(Tensor X)
    {
        var Y = m_Ops1.GlobalAvgVariancePool2D(X);
        var Z = m_Ops2.GlobalAvgVariancePool2D(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.GlobalAvgPool2D);
        return Y;
    }
    Tensor IOps.Border2D(Tensor x, int[] pad, float value)
    {
        var Y = m_Ops1.Border2D(x, pad, value);
        var Z = m_Ops2.Border2D(x, pad, value);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Border2D);
        return Y;
    }
    Tensor IOps.Pad2DReflect(Tensor x, int[] pad)
    {
        var Y = m_Ops1.Pad2DReflect(x, pad);
        var Z = m_Ops2.Pad2DReflect(x, pad);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Pad2DReflect);
        return Y;
    }
    Tensor IOps.Pad2DSymmetric(Tensor x, int[] pad)
    {
        var Y = m_Ops1.Pad2DSymmetric(x, pad);
        var Z = m_Ops2.Pad2DSymmetric(x, pad);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Pad2DSymmetric);
        return Y;
    }
    Tensor IOps.Pad2DEdge(Tensor x, int[] pad)
    {
        var Y = m_Ops1.Pad2DEdge(x, pad);
        var Z = m_Ops2.Pad2DEdge(x, pad);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Pad2DEdge);
        return Y;
    }
    Tensor IOps.ScaleBias(Tensor X, Tensor S, Tensor B)
    {
        var Y = m_Ops1.ScaleBias(X, S, B);
        var Z = m_Ops2.ScaleBias(X, S, B);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.ScaleBias);
        return Y;
    }
    Tensor IOps.Normalization(Tensor X, Tensor S, Tensor B, int pool, int axis, float epsilon)
    {
        var Y = m_Ops1.Normalization(X, S, B, pool, axis, epsilon);
        var Z = m_Ops2.Normalization(X, S, B, pool, axis, epsilon);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Normalization);
        return Y;
    }
    Tensor IOps.LRN(Tensor X, float alpha, float beta, float bias, int size)
    {
        var Y = m_Ops1.LRN(X, alpha, beta, bias, size);
        var Z = m_Ops2.LRN(X, alpha, beta, bias, size);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.LRN);
        return Y;
    }

    Tensor IOps.Dropout(Tensor X, float alpha)
    {
        var Y = m_Ops1.Dropout(X, alpha);
        var Z = m_Ops2.Dropout(X, alpha);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Dropout);
        return Y;
    }

    Tensor IOps.RandomNormal(TensorShape s, float mean, float scale, int seed)
    {
        var Y = m_Ops1.RandomNormal(s, mean, scale, seed);
        var Z = m_Ops2.RandomNormal(s, mean, scale, seed);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.RandomNormal);
        return Y;
    }
    Tensor IOps.RandomUniform(TensorShape s, float mean, float scale, int seed)
    {
        var Y = m_Ops1.RandomUniform(s, mean, scale, seed);
        var Z = m_Ops2.RandomUniform(s, mean, scale, seed);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.RandomUniform);
        return Y;
    }
    Tensor IOps.Multinomial(Tensor X, int count, int seed)
    {
        var Y = m_Ops1.Multinomial(X, count, seed);
        var Z = m_Ops2.Multinomial(X, count, seed);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Multinomial);
        return Y;
    }
    Tensor IOps.OneHot(Tensor X, int depth, float onValue, float offValue)
    {
        var Y = m_Ops1.OneHot(X, depth, onValue, offValue);
        var Z = m_Ops2.OneHot(X, depth, onValue, offValue);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.OneHot);
        return Y;
    }

    Tensor IOps.Relu(Tensor X)
    {
        var Y = m_Ops1.Relu(X);
        var Z = m_Ops2.Relu(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Relu);
        return Y;
    }
    Tensor IOps.Softmax(Tensor X)
    {
        var Y = m_Ops1.Softmax(X);
        var Z = m_Ops2.Softmax(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Softmax);
        return Y;
    }
    Tensor IOps.LogSoftmax(Tensor X)
    {
        var Y = m_Ops1.LogSoftmax(X);
        var Z = m_Ops2.LogSoftmax(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.LogSoftmax);
        return Y;
    }
    Tensor IOps.Tanh(Tensor X)
    {
        var Y = m_Ops1.Tanh(X);
        var Z = m_Ops2.Tanh(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Tanh);
        return Y;
    }
    Tensor IOps.Sigmoid(Tensor X)
    {
        var Y = m_Ops1.Sigmoid(X);
        var Z = m_Ops2.Sigmoid(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Sigmoid);
        return Y;
    }
    Tensor IOps.Elu(Tensor X, float alpha)
    {
        var Y = m_Ops1.Elu(X, alpha);
        var Z = m_Ops2.Elu(X, alpha);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Elu);
        return Y;
    }
    Tensor IOps.Relu6(Tensor X)
    {
        var Y = m_Ops1.Relu6(X);
        var Z = m_Ops2.Relu6(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Relu6);
        return Y;
    }
    Tensor IOps.LeakyRelu(Tensor X, float alpha)
    {
        var Y = m_Ops1.LeakyRelu(X, alpha);
        var Z = m_Ops2.LeakyRelu(X, alpha);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.LeakyRelu);
        return Y;
    }
    Tensor IOps.Selu(Tensor X, float alpha, float gamma)
    {
        var Y = m_Ops1.Selu(X, alpha, gamma);
        var Z = m_Ops2.Selu(X, alpha, gamma);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Selu);
        return Y;
    }
    Tensor IOps.PRelu(Tensor X, Tensor S)
    {
        var Y = m_Ops1.PRelu(X, S);
        var Z = m_Ops2.PRelu(X, S);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.PRelu);
        return Y;
    }
    Tensor IOps.Swish(Tensor X)
    {
        var Y = m_Ops1.Swish(X);
        var Z = m_Ops2.Swish(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Swish);
        return Y;
    }

    Tensor IOps.Abs(Tensor X)
    {
        var Y = m_Ops1.Abs(X);
        var Z = m_Ops2.Abs(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Abs);
        return Y;
    }
    Tensor IOps.Neg(Tensor X)
    {
        var Y = m_Ops1.Neg(X);
        var Z = m_Ops2.Neg(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Neg);
        return Y;
    }
    Tensor IOps.Ceil(Tensor X)
    {
        var Y = m_Ops1.Ceil(X);
        var Z = m_Ops2.Ceil(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Ceil);
        return Y;
    }
    Tensor IOps.Clip(Tensor X, float min, float max)
    {
        var Y = m_Ops1.Clip(X, min, max);
        var Z = m_Ops2.Clip(X, min, max);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Clip);
        return Y;
    }
    Tensor IOps.Floor(Tensor X)
    {
        var Y = m_Ops1.Floor(X);
        var Z = m_Ops2.Floor(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Floor);
        return Y;
    }

    Tensor IOps.Reciprocal(Tensor X)
    {
        var Y = m_Ops1.Reciprocal(X);
        var Z = m_Ops2.Reciprocal(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Reciprocal);
        return Y;
    }
    Tensor IOps.Pow(Tensor X, float alpha)
    {
        var Y = m_Ops1.Pow(X, alpha);
        var Z = m_Ops2.Pow(X, alpha);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Pow);
        return Y;
    }
    Tensor IOps.Exp(Tensor X)
    {
        var Y = m_Ops1.Exp(X);
        var Z = m_Ops2.Exp(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Exp);
        return Y;
    }
    Tensor IOps.Log(Tensor X)
    {
        var Y = m_Ops1.Log(X);
        var Z = m_Ops2.Log(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Log);
        return Y;
    }
    Tensor IOps.Sqrt(Tensor X)
    {
        var Y = m_Ops1.Sqrt(X);
        var Z = m_Ops2.Sqrt(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Activation + " " + Layer.Activation.Sqrt);
        return Y;
    }

    Tensor IOps.Add(Tensor[] tensors)
    {
        var Y = m_Ops1.Add(tensors);
        var Z = m_Ops2.Add(tensors);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Add);
        return Y;
    }
    Tensor IOps.Sub(Tensor[] tensors)
    {
        var Y = m_Ops1.Sub(tensors);
        var Z = m_Ops2.Sub(tensors);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Sub);
        return Y;
    }
    Tensor IOps.Mul(Tensor[] tensors)
    {
        var Y = m_Ops1.Mul(tensors);
        var Z = m_Ops2.Mul(tensors);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Mul, tensors);
        return Y;
    }
    Tensor IOps.Div(Tensor[] tensors)
    {
        var Y = m_Ops1.Div(tensors);
        var Z = m_Ops2.Div(tensors);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Div);
        return Y;
    }
    Tensor IOps.Pow(Tensor[] tensors)
    {
        var Y = m_Ops1.Pow(tensors);
        var Z = m_Ops2.Pow(tensors);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Pow);
        return Y;
    }
    Tensor IOps.Min(Tensor[] tensors)
    {
        var Y = m_Ops1.Min(tensors);
        var Z = m_Ops2.Min(tensors);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Min);
        return Y;
    }
    Tensor IOps.Max(Tensor[] tensors)
    {
        var Y = m_Ops1.Max(tensors);
        var Z = m_Ops2.Max(tensors);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Max);
        return Y;
    }
    Tensor IOps.Mean(Tensor[] tensors)
    {
        var Y = m_Ops1.Mean(tensors);
        var Z = m_Ops2.Mean(tensors);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Mean);
        return Y;
    }

    Tensor IOps.ReduceMax(Tensor X, int axis)
    {
        var Y = m_Ops1.ReduceMax(X, axis);
        var Z = m_Ops2.ReduceMax(X, axis);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.ReduceMax);
        return Y;
    }
    Tensor IOps.ReduceMean(Tensor X, int axis)
    {
        var Y = m_Ops1.ReduceMean(X, axis);
        var Z = m_Ops2.ReduceMean(X, axis);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.ReduceMean);
        return Y;
    }
    Tensor IOps.ReduceMin(Tensor X, int axis)
    {
        var Y = m_Ops1.ReduceMin(X, axis);
        var Z = m_Ops2.ReduceMin(X, axis);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.ReduceMin);
        return Y;
    }
    Tensor IOps.ReduceProd(Tensor X, int axis)
    {
        var Y = m_Ops1.ReduceProd(X, axis);
        var Z = m_Ops2.ReduceProd(X, axis);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.ReduceProd);
        return Y;
    }
    Tensor IOps.ReduceSum(Tensor X, int axis)
    {
        var Y = m_Ops1.ReduceSum(X, axis);
        var Z = m_Ops2.ReduceSum(X, axis);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.ReduceSum);
        return Y;
    }

    Tensor IOps.Greater(Tensor a, Tensor b)
    {
        var Y = m_Ops1.Greater(a, b);
        var Z = m_Ops2.Greater(a, b);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Greater);
        return Y;
    }
    Tensor IOps.GreaterEqual(Tensor a, Tensor b)
    {
        var Y = m_Ops1.GreaterEqual(a, b);
        var Z = m_Ops2.GreaterEqual(a, b);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.GreaterEqual);
        return Y;
    }
    Tensor IOps.Less(Tensor a, Tensor b)
    {
        var Y = m_Ops1.Less(a, b);
        var Z = m_Ops2.Less(a, b);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Less);
        return Y;

    }
    Tensor IOps.LessEqual(Tensor a, Tensor b)
    {
        var Y = m_Ops1.LessEqual(a, b);
        var Z = m_Ops2.LessEqual(a, b);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.LessEqual);
        return Y;
    }
    Tensor IOps.Equal(Tensor a, Tensor b)
    {
        var Y = m_Ops1.Equal(a, b);
        var Z = m_Ops2.Equal(a, b);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Equal);
        return Y;
    }
    Tensor IOps.LogicalOr(Tensor a, Tensor b)
    {
        var Y = m_Ops1.LogicalOr(a, b);
        var Z = m_Ops2.LogicalOr(a, b);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.LogicalOr);
        return Y;
    }
    Tensor IOps.LogicalAnd(Tensor a, Tensor b)
    {
        var Y = m_Ops1.LogicalAnd(a, b);
        var Z = m_Ops2.LogicalAnd(a, b);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.LogicalAnd);
        return Y;
    }
    Tensor IOps.LogicalXor(Tensor a, Tensor b)
    {
        var Y = m_Ops1.LogicalXor(a, b);
        var Z = m_Ops2.LogicalXor(a, b);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.LogicalXor);
        return Y;
    }
    Tensor IOps.LogicalNot(Tensor x)
    {
        var Y = m_Ops1.LogicalNot(x);
        var Z = m_Ops2.LogicalNot(x);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.LogicalNot);
        return Y;
    }

    Tensor IOps.Flatten(Tensor X)
    {
        var Y = m_Ops1.Flatten(X);
        var Z = m_Ops2.Flatten(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Flatten);
        return Y;
    }
    Tensor IOps.Reshape(Tensor X, TensorShape shape)
    {
        var Y = m_Ops1.Reshape(X, shape);
        var Z = m_Ops2.Reshape(X, shape);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Reshape);
        return Y;
    }
    Tensor IOps.Transpose(Tensor X)
    {
        var Y = m_Ops1.Transpose(X);
        var Z = m_Ops2.Transpose(X);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Transpose);
        return Y;
    }
    Tensor IOps.Gather(Tensor[] tensors, int axis)
    {
        var Y = m_Ops1.Gather(tensors, axis);
        var Z = m_Ops2.Gather(tensors, axis);
        CheckSame(m_DifferenceAsError, Y,Z, Layer.Type.Gather);
        return Y;
    }
    Tensor IOps.Concat(Tensor[] tensors, int axis)
    {
        var Y = m_Ops1.Concat(tensors, axis);
        var Z = m_Ops2.Concat(tensors, axis);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Concat);
        return Y;
    }
    Tensor IOps.StridedSlice(Tensor X, int[] starts, int[] ends, int[] strides)
    {
        var Y = m_Ops1.StridedSlice(X, starts, ends, strides);
        var Z = m_Ops2.StridedSlice(X, starts, ends, strides);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.StridedSlice);
        return Y;
    }
    Tensor IOps.Tile(Tensor X, int[] repeats)
    {
        var Y = m_Ops1.Tile(X, repeats);
        var Z = m_Ops2.Tile(X, repeats);
        CheckSame(m_DifferenceAsError, Y, Z, Layer.Type.Tile);
        return Y;
    }
    Tensor IOps.Copy(Tensor x)
    {
        var Y = m_Ops1.Copy(x);
        var Z = m_Ops2.Copy(x);
        CheckSame(m_DifferenceAsError, Y, Z, "Copy");
        return Y;
    }

    Tensor IOps.Prepare(Tensor X)
    {
        var Y = m_Ops1.Prepare(X);
        var Z = m_Ops2.Prepare(X);
        CheckSame(m_DifferenceAsError, Y, Z, "Prepare");
        return Y;
    }

    void IOps.ResetAllocator(bool keepCachedMemory)
    {
        m_Ops1.ResetAllocator(keepCachedMemory);
        m_Ops2.ResetAllocator(keepCachedMemory);
    }

    // -----
    static public void CheckSame(bool differenceAsError, Tensor X, Tensor Y, Layer.Type type, params Tensor[] inputs)
    {
        CheckSame(differenceAsError, X, Y, type.ToString(), inputs);
    }

    static public void CheckSame(bool differenceAsError, Tensor X, Tensor Y, string opName, params Tensor[] inputs)
    {
        if (!X.Approximately(Y))
        {
            if (differenceAsError)
            {
                string mainLogMessage = $"Tensors not equal after {opName}";
                D.LogError(mainLogMessage);
            }
            else
            {
                string mainLogMessage = $"Tensors not equal after {opName} max error: {X.MaxDifference(Y)}";
                D.LogWarning(mainLogMessage);

                D.Log("First: " + X.shape);
                D.Log("Second:" + Y.shape);

                X.PrintDataPart(X.channels * X.width * 2);
                Y.PrintDataPart(Y.channels * Y.width * 2);

                for (var i = 0; i < inputs.Length; i++)
                {
                    inputs[i].PrintDataPart(32, "input_" + i);
                }
            }


        }
        if (X.tensorOnDevice != Y.tensorOnDevice)
            Y.Dispose();
    }

    static public void CheckApproximately(bool differenceAsError, Tensor X, Tensor Y, int count, float epsilon, Layer.Type type)
    {
        CheckApproximately(differenceAsError, X, Y, count, epsilon, type.ToString());
    }

    static public void CheckApproximately(bool differenceAsError, Tensor X, Tensor Y, int count, float epsilon, string opName)
    {
        if (!X.Approximately(Y, epsilon, count))
        {
            string mainLogMessage = $"Tensors not equal after {opName}";
            if (differenceAsError)
                D.LogError(mainLogMessage);
            else
                D.LogWarning(mainLogMessage);

            D.Log("First: " + X.shape);
            D.Log("Second:" + Y.shape);

            if (count < 0)
                count = X.channels * X.width * 2;
            X.PrintDataPart(count);
            Y.PrintDataPart(count);
        }
        if (X.tensorOnDevice != Y.tensorOnDevice)
            Y.Dispose();
    }
}


} // namespace Barracuda
