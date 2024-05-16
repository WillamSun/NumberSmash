﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NumberGamePlus.Classes;

namespace NumberGamePlus.Components
{
    public partial class Equation : UserControl
    {
        public readonly List<Number> Numbers = new List<Number>();
        public readonly List<Plus> Pluses = new List<Plus>();

        public Equation()
        {
            InitializeComponent();
            foreach (var ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is Number number)
                    Numbers.Add(number);
                if (ctrl is Plus plus)
                    Pluses.Add(plus);
            }
        }

        private Random _RandomGenerator;

        private bool _ExtendedFeaturesToggle = false;

        public bool ExtendedFeaturesToggle
        {
            get => _ExtendedFeaturesToggle;
            set
            {
                _ExtendedFeaturesToggle = value;
                foreach (var number in Numbers)
                    number.ExtendedFeaturesToggle = value;
            }
        }

        [Browsable(false), ReadOnly(true)]
        public Random RandomGenerator
        {
            get => _RandomGenerator;
            set
            {
                if (value == null) return;
                _RandomGenerator = value;
                foreach (var number in Numbers)
                {
                    number.RandomGenerator = value;
                }
            }
        }

        private List<int> _SelectedIndices = new List<int>();

        [Browsable(false), ReadOnly(true)]
        public int[] SelectedIndices
        {
            get => SelectedIndices;
            set
            {
                foreach (var i in value)
                    Numbers[i].Selected = true;
                _SelectedIndices = value.ToList();
            }
        }

        private List<Number> _SelectedItems = new List<Number>();

        [Browsable(false), ReadOnly(true)]
        public Number[] SelectedItems
        {
            get => _SelectedItems.ToArray();
            set
            {
                foreach (var i in Numbers)
                    i.Selected = false;
                foreach (var i in value)
                    i.Selected = true;
                _SelectedItems = value.ToList();
            }
        }

        private int _SelectedSum = int.MinValue;

        [Browsable(false), ReadOnly(true)]
        public int SelectedSum
        {
            get
            {
                if (UncommonNumberSelected)
                    throw new Exception("Uncalculatable");
                return _SelectedSum;
            }
            private set => throw new ReadOnlyException();
        }

        public bool IsSelected(NumberValue.NumberType type)
        {
            foreach (var i in Numbers)
                if (i.Value.Type == type)
                    return true;
            return false;
        }

        public delegate void SelectedItemsChangedHandle(object sender, EventArgs e);

        public event SelectedItemsChangedHandle SelectedItemsChanged;

        private void _SelectedItemsChangedToggle()
        {
            if (SelectedItemsChanged != null)
                SelectedItemsChanged(this, EventArgs.Empty);
        }

        public void InitNumbers()
        {
            foreach (var number in Numbers)
                number.InitNumber();
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                foreach (var ctrl in tableLayoutPanel1.Controls)
                {
                    if (ctrl is Number number)
                        number.Font = value;
                    else if (ctrl is Plus plus)
                        plus.Font = value;
                }
            }
        }

        private void number_SelectedChanged(object sender, EventArgs e)
        {
            UpdateProperties(false);
            _SelectedItemsChangedToggle();
        }

        private void UpdateProperties(bool update_values)
        {
            Number n;
            NumberValue n_value;
            _SelectedSum = 0;
            _SelectedItems.Clear();
            _SelectedIndices.Clear();
            if (update_values)
            {
                _Values.Clear();
                _MinSum = _MaxSum = _Sum = 0;
            }
            _UncommonNumberSelected = false;
            for (var i = 0; i < Numbers.Count; i++)
            {
                n = Numbers[i];
                n_value = n.Value;
                if (n.Selected)
                {
                    _SelectedItems.Add(n);
                    _SelectedIndices.Add(i);
                    _SelectedSum += n_value.Value;
                    if (n_value.Type != NumberValue.NumberType.Common)
                        _UncommonNumberSelected = true;
                }
                if (!update_values) continue;
                _Values.Add(n_value);
                _Sum += n_value.Value;
                // TODO: Rewrite
                if (n_value.Value <= 0)
                    _MinSum += n_value.Value;
                else
                    _MaxSum += n_value.Value;
            }
            if (_SelectedIndices.Count <= 0)
                _SelectedSum = int.MinValue;
        }

        private bool _UncommonNumberSelected = false;

        [Browsable(false), ReadOnly(true)]
        public bool UncommonNumberSelected
        {
            get => _UncommonNumberSelected;
            set => throw new ReadOnlyException();
        }

        private List<NumberValue> _Values = new List<NumberValue>();

        [Browsable(false), ReadOnly(true)]
        public NumberValue[] Values
        {
            get => _Values.ToArray();
            set
            {
                if (value.Length > Numbers.Count())
                    throw new ArgumentOutOfRangeException();
                Numbers.Zip(value, (n, v) => { n.Value = v; return n; });
                _Values = value.ToList();
            }
        }

        private void Equation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue <= '9' && e.KeyValue >= '1')
            {
                Numbers[e.KeyValue - '0'].Selected ^= true;
            }
        }

        private void number_ValueChanged(object sender, EventArgs e)
        {
            UpdateProperties(true);
        }

        private int _Sum;

        [Browsable(false), ReadOnly(true)]
        public int Sum
        {
            get
            {
                if (_UncommonNumberSelected)
                    throw new Exception("Uncalculatable");
                return _Sum;
            }
            private set => throw new ReadOnlyException();
        }

        private int _MaxSum;

        [Browsable(false), ReadOnly(true)]
        public int MaxSum
        {
            get => _MaxSum;
            private set => throw new ReadOnlyException();
        }

        private int _MinSum;

        [Browsable(false), ReadOnly(true)]
        public int MinSum
        {
            get => _MinSum;
            private set => throw new ReadOnlyException();
        }
    }
}
