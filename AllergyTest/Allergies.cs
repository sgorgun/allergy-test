using System;

namespace AllergyTest
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        private readonly int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class with test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        public Allergies(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException($"{score} is less than zero.", nameof(score));
            }

            this.score = score;
        }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            return ((int)allergens & this.score) != 0;
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            List<Allergens> allergensList = new List<Allergens>();
            foreach (Allergens allergen in Enum.GetValues(typeof(Allergens)))
            {
                if (this.IsAllergicTo(allergen))
                {
                    allergensList.Add(allergen);
                }
            }

            return allergensList.ToArray();
        }
    }
}
