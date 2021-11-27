using AssetManagementSystem.Models;
using AssetManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        //Constructor Dependency Injection for AssetRepository        
        IAssetRepository assetRepository;
        public AssetController(IAssetRepository _p)
        {
            assetRepository = _p;
        }

        #region Http Get functions get all and get by id        
        [HttpGet]
        public async Task<IActionResult> GetAssets()
        {
            try
            {
                var assets = await assetRepository.GetAsset();
                if (assets == null)
                {
                    return NotFound();
                }
                return Ok(assets);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public Task<ActionResult<AssetMasterTable>> GetAssetById(int id)
        {
            try
            {
                var asset = assetRepository.GetAssetById(id);
                if (asset == null)
                {
                    return null;
                }
                return asset;
            }

            catch (Exception)
            {

                return null;
            }
        }

        #endregion

        #region Add Asset
        [HttpPost]
        public async Task<IActionResult> AddAsset([FromBody] AssetMasterTable model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var assetId = await assetRepository.AddAsset(model);
                    if (assetId > 0)
                    {
                        return Ok(assetId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update Client
        [HttpPut]       
        public async Task<IActionResult> UpdateAsset([FromBody] AssetMasterTable model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await assetRepository.UpdateAsset(model);
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Delete Asset
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await assetRepository.DeleteAsset(id);
                    return Ok(id);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

    }
}
