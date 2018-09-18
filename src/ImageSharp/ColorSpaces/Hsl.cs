﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces
{
    /// <summary>
    /// Represents a Hsl (hue, saturation, lightness) color.
    /// </summary>
    public readonly struct Hsl : IEquatable<Hsl>
    {
        /// <summary>
        /// Max range used for clamping.
        /// </summary>
        private static readonly Vector3 VectorMax = new Vector3(360, 1, 1);

        /// <summary>
        /// Gets the hue component.
        /// <remarks>A value ranging between 0 and 360.</remarks>
        /// </summary>
        public readonly float H;

        /// <summary>
        /// Gets the saturation component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public readonly float S;

        /// <summary>
        /// Gets the lightness component.
        /// <remarks>A value ranging between 0 and 1.</remarks>
        /// </summary>
        public readonly float L;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hsl"/> struct.
        /// </summary>
        /// <param name="h">The h hue component.</param>
        /// <param name="s">The s saturation component.</param>
        /// <param name="l">The l value (lightness) component.</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public Hsl(float h, float s, float l)
            : this(new Vector3(h, s, l))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hsl"/> struct.
        /// </summary>
        /// <param name="vector">The vector representing the h, s, l components.</param>
        [MethodImpl(InliningOptions.ShortMethod)]
        public Hsl(Vector3 vector)
        {
            vector = Vector3.Clamp(vector, Vector3.Zero, VectorMax);
            this.H = vector.X;
            this.S = vector.Y;
            this.L = vector.Z;
        }

        /// <summary>
        /// Compares two <see cref="Hsl"/> objects for equality.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Hsl"/> on the left side of the operand.
        /// </param>
        /// <param name="right">The <see cref="Hsl"/> on the right side of the operand.</param>
        /// <returns>
        /// True if the current left is equal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        [MethodImpl(InliningOptions.ShortMethod)]
        public static bool operator ==(Hsl left, Hsl right) => left.Equals(right);

        /// <summary>
        /// Compares two <see cref="Hsl"/> objects for inequality.
        /// </summary>
        /// <param name="left">The <see cref="Hsl"/> on the left side of the operand.</param>
        /// <param name="right">The <see cref="Hsl"/> on the right side of the operand.</param>
        /// <returns>
        /// True if the current left is unequal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        [MethodImpl(InliningOptions.ShortMethod)]
        public static bool operator !=(Hsl left, Hsl right) => !left.Equals(right);

        /// <inheritdoc/>
        [MethodImpl(InliningOptions.ShortMethod)]
        public override int GetHashCode()
        {
            int hash = this.H.GetHashCode();
            hash = HashHelpers.Combine(hash, this.S.GetHashCode());
            return HashHelpers.Combine(hash, this.L.GetHashCode());
        }

        /// <inheritdoc/>
        public override string ToString() => $"Hsl [ H={this.H:#0.##}, S={this.S:#0.##}, L={this.L:#0.##} ]";

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is Hsl other && this.Equals(other);

        /// <inheritdoc/>
        [MethodImpl(InliningOptions.ShortMethod)]
        public bool Equals(Hsl other)
        {
            return this.H.Equals(other.H)
                && this.S.Equals(other.S)
                && this.L.Equals(other.L);
        }
    }
}