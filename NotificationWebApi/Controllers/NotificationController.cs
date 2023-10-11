using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotificationWebApi.DTO;
using NotificationWebApi.Repository;
using System;
using System.Threading.Tasks;

namespace NotificationWebApi.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> GetNotifications(int userId)
        {
            try
            {
                var notifications = await _notificationRepository.GetNotificationsBy(userId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("{userId}/{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> GetNotificationById(int userId, int id)
        {
            try
            {
                var notification = await _notificationRepository.GetNotificationById(userId, id);
                if (notification != null)
                {
                    return Ok(notification);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> AddNotification(NotificationDTO notificationDto)
        {
            try
            {
                var newNotification = await _notificationRepository.AddNotification(notificationDto);
                return Ok(newNotification);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> UpdateNotification(int id, NotificationDTO notificationDto)
        {
            try
            {
                var result = await _notificationRepository.UpdateNotification(id, notificationDto);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            try
            {
                await _notificationRepository.DeleteNotification(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("{id}/check/{userId}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> CheckNotification(int id, int userId)
        {
            try
            {
                await _notificationRepository.CheckNotification(id, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("{id}/uncheck/{userId}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> UncheckNotification(int id, int userId)
        {
            try
            {
                await _notificationRepository.UncheckNotification(id, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}