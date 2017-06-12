using Sitecore.Commerce.Data.Products;
using Sitecore.Commerce.Entities.Products;
using Sitecore.Data.Events;
using Sitecore.Data.Items;

namespace Sitecore.Support.Commerce.Data.Products
{
    public class SpecificationRepository : Sitecore.Commerce.Data.Products.SpecificationRepository
    {
        public SpecificationRepository(string specificationTemplateId, string specificationLookupTemplateId, ArtifactRepository<GlobalSpecificationOption> specificationOptionRepository) : base(specificationTemplateId, specificationLookupTemplateId, specificationOptionRepository)
        {
        }
        protected override void UpdateEntityItem(Item entityItem, GlobalSpecification entity)
        {
            #region fix
            //using EventDisabler to prevent any event to be faired while updating items. The indexes will be rebuilt at the end, the caches will be cleaned up.
            using (new EventDisabler())
            {
                base.UpdateEntityItem(entityItem, entity);
            }
            #endregion
        }
    }
}