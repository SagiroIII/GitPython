# Generated by Django 3.2.5 on 2021-11-30 01:16

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('VLIGSJP', '0006_auto_20211126_1835'),
    ]

    operations = [
        migrations.DeleteModel(
            name='CategoriaPeliculas',
        ),
        migrations.DeleteModel(
            name='ClasificacionJuego',
        ),
        migrations.DeleteModel(
            name='Estrenos',
        ),
        migrations.RemoveField(
            model_name='ventasjuegos',
            name='Titulo',
        ),
        migrations.RemoveField(
            model_name='ventaspeliculas',
            name='Titulo',
        ),
        migrations.DeleteModel(
            name='CatJuegos',
        ),
        migrations.DeleteModel(
            name='CatPeliculas',
        ),
        migrations.DeleteModel(
            name='VentasJuegos',
        ),
        migrations.DeleteModel(
            name='VentasPeliculas',
        ),
    ]