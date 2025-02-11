﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wpf.Ui.Contracts;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.IconElements;
using SymbolIcon = Wpf.Ui.Controls.IconElements.SymbolIcon;

namespace Wpf.Ui.Gallery.ViewModels.Pages.DialogsAndFlyouts;

public partial class SnackbarViewModel : ObservableObject
{
    private readonly ISnackbarService _snackbarService;

    private ControlAppearance _snackbarAppearance = ControlAppearance.Secondary;

    [ObservableProperty]
    private int _snackbarTimeout = 2000;

    private int _snackbarAppearanceComboBoxSelectedIndex = 1;

    public int SnackbarAppearanceComboBoxSelectedIndex
    {
        get => _snackbarAppearanceComboBoxSelectedIndex;
        set
        {
            SetProperty<int>(ref _snackbarAppearanceComboBoxSelectedIndex, value);
            UpdateSnackbarAppearance(value);
        }
    }

    public SnackbarViewModel(ISnackbarService snackbarService)
    {
        _snackbarService = snackbarService;
    }

    [RelayCommand]
    private void OnOpenSnackbar(object sender)
    {
        _snackbarService.Timeout = SnackbarTimeout;
        _snackbarService.Show("Don't Blame Yourself.", "No Witcher's Ever Died In His Bed.", new SymbolIcon(SymbolRegular.Fluent24), _snackbarAppearance);
    }

    private void UpdateSnackbarAppearance(int appearanceIndex)
    {
        _snackbarAppearance = appearanceIndex switch
        {
            1 => ControlAppearance.Secondary,
            2 => ControlAppearance.Info,
            3 => ControlAppearance.Success,
            4 => ControlAppearance.Caution,
            5 => ControlAppearance.Danger,
            6 => ControlAppearance.Light,
            7 => ControlAppearance.Dark,
            8 => ControlAppearance.Transparent,
            _ => ControlAppearance.Primary
        };
    }
}
