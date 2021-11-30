# Generated by Django 3.2.5 on 2021-11-30 07:27

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('VLIGSJP', '0009_auto_20211129_2326'),
    ]

    operations = [
        migrations.CreateModel(
            name='CategoriaJuegos',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('TipoCategoria', models.CharField(max_length=20)),
            ],
        ),
        migrations.CreateModel(
            name='CategoriaPeliculas',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('TipoCategoria', models.CharField(max_length=20)),
            ],
        ),
        migrations.CreateModel(
            name='CatJuegos',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('Titulo', models.CharField(max_length=50)),
                ('Descripcion', models.CharField(max_length=300)),
                ('Fecha', models.CharField(max_length=50)),
                ('Precio', models.FloatField()),
                ('Categoria', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='VLIGSJP.categoriajuegos')),
            ],
        ),
        migrations.CreateModel(
            name='CatPeliculas',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('Titulo', models.CharField(max_length=50)),
                ('Descripcion', models.CharField(max_length=300)),
                ('Duracion', models.IntegerField()),
                ('Fecha', models.CharField(max_length=50)),
                ('Precio', models.FloatField()),
                ('Categoria', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='VLIGSJP.categoriapeliculas')),
            ],
        ),
        migrations.CreateModel(
            name='ClasificacionJuegos',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('TipoClasificacion', models.CharField(max_length=20)),
            ],
        ),
        migrations.CreateModel(
            name='Estrenos',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('Titulo', models.CharField(max_length=50)),
                ('Descripcion', models.CharField(max_length=300)),
                ('Tipo', models.CharField(max_length=10)),
            ],
        ),
        migrations.CreateModel(
            name='VentasPeliculas',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('Precio', models.FloatField()),
                ('NombreCliente', models.CharField(max_length=50)),
                ('CorreoCliente', models.EmailField(max_length=254)),
                ('FechaCompra', models.CharField(max_length=50)),
                ('Titulo', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='VLIGSJP.catpeliculas')),
            ],
        ),
        migrations.CreateModel(
            name='VentasJuegos',
            fields=[
                ('id', models.BigAutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('Precio', models.FloatField()),
                ('NombreCliente', models.CharField(max_length=50)),
                ('CorreoCliente', models.EmailField(max_length=254)),
                ('FechaCompra', models.CharField(max_length=50)),
                ('Titulo', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='VLIGSJP.catjuegos')),
            ],
        ),
        migrations.AddField(
            model_name='catjuegos',
            name='Clasificacion',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='VLIGSJP.clasificacionjuegos'),
        ),
    ]
