using AutoMapper;
using GeekShopping.Cart.Api.Domain.Dto;
using GeekShopping.Cart.Api.Domain.Interfaces.IRepository;
using GeekShopping.Cart.Api.Domain.Interfaces.IServices;
using GeekShopping.Cart.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Cart.Api.Domain.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CartServices(ICartRepository cartRepository, IMapper mapper, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            return await _cartRepository.ApplyCoupon(userId, couponCode);
        }

        public async Task<bool> Clear(string userId)
        {
            return await _cartRepository.Clear(userId);
        }

        public async Task<CartDto> FindByUserId(string userId)
        {
            var cart = await _cartRepository.FindByUserId(userId);

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            return await _cartRepository.RemoveCoupon(userId);
        }

        public async Task<bool> Remove(long cartDetailsId)
        {
            try
            {
                return await _cartRepository.Remove(cartDetailsId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CartDto> Save(CartDto dto)
        {
            try
            {
                var ent = _mapper.Map<Entities.Cart>(dto);

                var existProduct = await _productRepository.Existe(ent.CartDetails.FirstOrDefault().ProductId);

                if (!existProduct)
                    await _productRepository.Save(ent.CartDetails.FirstOrDefault().Product);

                var result = await _cartRepository.Save(ent);

                return _mapper.Map<CartDto>(result);                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<CartDto> Update(CartDto dto)
        {
            var ent = _mapper.Map<Entities.Cart>(dto);

            var existProduct = await _productRepository.Existe(ent.CartDetails.FirstOrDefault().ProductId);

            if (!existProduct)
                await _productRepository.Save(ent.CartDetails.FirstOrDefault().Product);

            var result = await _cartRepository.Save(ent);

            return _mapper.Map<CartDto>(result);
        }

        public async Task<CartDto> SaveOrUpdate(CartDto dto)
        {
            var ent = _mapper.Map<Entities.Cart>(dto);

            var existProduct = await _productRepository.Existe(ent.CartDetails.FirstOrDefault().ProductId);

            if (!existProduct)
                await _productRepository.Save(ent.CartDetails.FirstOrDefault().Product);


            if (!await _cartRepository.CartHeaderExist(ent.CartHeader.UserId))
                await _cartRepository.Save(ent);
            else
                await _cartRepository.Update(ent);


            return _mapper.Map<CartDto>(ent);
        }
    }
}
