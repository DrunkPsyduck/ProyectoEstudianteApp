using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoEstudianteApp.CustomControls
{
    public class CustomViewCellControl : ViewCell
    {
        public static readonly BindableProperty SelectedItemBackgroundColorProperty =
           BindableProperty.Create("SelectedItemBackgroundColor"
               , typeof(Color), typeof(CustomViewCellControl), Color.White);
        //AQUI REALIZAMOS LA ACCION PARA LA PROPIEDAD EN XAML
        public Color SelectedItemBackgroundColor
        {
            get
            {
                return (Color)GetValue(SelectedItemBackgroundColorProperty);
            }
            set
            {
                SetValue(SelectedItemBackgroundColorProperty, value);
            }
        }
    }
}
