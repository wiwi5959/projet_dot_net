using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 

namespace projet_dot_net.Repository
{
    public class EtudiantRepository
    {
        private AppContext context;

        public class EtudiantRepository (AppContext context)

            {
            
            this.context = context;

            }

    public IQueryable<Etudiant> FindAll()
    {
        // SELECT * FROM Etudiant;
        
        return this.context.Etudiant.Select(etudiant => etudiant);

    }

