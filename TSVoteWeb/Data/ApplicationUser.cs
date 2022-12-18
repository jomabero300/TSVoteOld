using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using TSVoteWeb.Data.Entities.Gene;
using TSVoteWeb.Data.Entities.Vote;

namespace TSVoteWeb.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:5084/images/noimage.png"
            : $"https://localhost:5084/images/users/{ImageId}.png";


        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Lugar de vivienda")]
        public NeighborhoodSidewalk NeighborhoodSidewalk { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Genero")]
        public Gender Gender { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        [Display(Name = "Referido")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(450, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Referred { get; set; }

        [Display(Name = "Lugar de votación")]
        public Poll Poll { get; set; }

        [Display(Name = "Grupo")]
        public GroupType GroupType { get; set; }

        [Display(Name = "Mesa")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Usted debe seleccionar una {0}")]
        public int PollingStation { get; set; }

        [Display(Name = "Voto")]
        public bool isVote { get; set; }
        
        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";          

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";
    }
}