//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public double GetProductionCost()
        {
            double inputCost = 0;
            double equipmentCost = 0;
    
            foreach (Step step in this.steps)
            {
                inputCost += step.Quantity * step.Input.UnitCost;
                equipmentCost += step.Time * step.Equipment.HourlyCost / 60.0; // Convertir minutos a horas
            }
    
            return inputCost + equipmentCost;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
                Console.WriteLine($"Costo total de producción: {GetProductionCost()}");
        }

    }
}

//La respuesta a la pregunta "¿Qué patrón o principio usan para asignar esta responsabilidad?" sería el principio SOLID de Responsabilidad Única (SRP), 
//ya que se está asignando una única responsabilidad (calcular el costo total de producción) a la clase Recipe, que es la que tiene la información necesaria para realizar este cálculo. 
//Además, la implementación del cálculo del costo total no afecta la funcionalidad original de la clase Recipe.
