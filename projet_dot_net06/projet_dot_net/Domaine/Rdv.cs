using System;
using System.Collections.Generic;

namespace projet_dot_net.Domaine
{
    public partial class Rdv
    {
        public int Id { get; set; }
        public int EntrepriseId { get; set; }
        public int EtudiantId { get; set; }
        public string Proposition { get; set; }
        public string DureeDuStage { get; set; }
        public DateTime? Date { get; set; }

        public virtual Entreprise Entreprise { get; set; }
        public virtual Etudiant Etudiant { get; set; }
    }
}
